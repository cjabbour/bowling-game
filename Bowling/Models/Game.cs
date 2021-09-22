using System.Collections.Generic;
using System.Linq;

namespace Bowling.Models
{
    public class Game
    {
        public List<Frame> Frames { get; set; }

        public Game()
        {
            Frames = new List<Frame>();
        }

        public int GetScore()
        {
            int score = CompletedFrames().Select(f => f.PinCount()).Sum();

            foreach (var frm in CompletedFrames())
            {
                if (frm.IsStrike())
                {
                    score += RollsAfterFrame(frm.FrameNumber, 2).Select(r => r.Pins).Sum();
                }

                if (frm.IsSpare())
                {
                    score += RollsAfterFrame(frm.FrameNumber, 1).Select(r => r.Pins).Sum();
                }
            }
            return score;
        }

        public bool IsComplete() => CompletedFrames().Count() == 10;

        public IEnumerable<Frame> CompletedFrames()
        {
            return Frames.Where(f => f.IsComplete());
        }

        private IEnumerable<Roll> RollsAfterFrame(int frameNumber, int numberOfRolls)
        {
            var frames = Frames.Where(f => f.FrameNumber > frameNumber)
                .OrderBy(r => r.FrameNumber)
                .Take(numberOfRolls*2);

            return frames.SelectMany(f => f.Rolls).Take(numberOfRolls);
        }


        public static string GetScoreMessage(int score)
        {
            if (score.IsBetween(100, 150))
            {
                return "Novice Score. Keep practicing and you'll get there";
            }
            if (score.IsBetween(151, 200))
            {
                return "Not bad! You stand a chance against most children";
            }
            if (score.IsBetween(201, 250))
            {
                return "Nice job! I see you've been practicing";
            }
            if (score.IsBetween(251, 299))
            {
                return "Wow! Ever thought about giving lessons?";
            }
            if (score == 300) { return "Are you kidding me? That was amazing!"; }

            return "Have you ever even seen a bowling ball before? Maybe this isn't for you :(";
        }

    }
}
