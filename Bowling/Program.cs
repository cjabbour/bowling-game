using System;
using System.Linq;
using Bowling.Models;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready to Bowl?!");

            Game theGame = new Game();
            while (!theGame.IsComplete())
            {

                var currentFrame = theGame.Frames.LastOrDefault();
                if (currentFrame == null || currentFrame.IsComplete())
                {
                    theGame.Frames.Add(new Frame(theGame.Frames.Count+1));
                    currentFrame = theGame.Frames.LastOrDefault();
                }

                var prompt = $"Frame {currentFrame.FrameNumber} Roll {currentFrame.Rolls?.Count + 1}";
                var pins = PromptForPins(prompt);

                var pinsStanding = 10 - currentFrame.PinCount();
                if (currentFrame.FrameNumber == 10)
                {
                    if (currentFrame.Rolls.Count == 1 && currentFrame.PinCount() == 10)
                    {
                        //already rolled once knocked down 10 - no spare - 10 more were stood up
                        pinsStanding = 10;
                    }
                    if (currentFrame.Rolls.Count == 2)
                    {
                        //already rolled twice - this is 3rd
                        pinsStanding = 10;
                    }
                }

                while (pins > (pinsStanding) || pins < 0)
                {
                    Console.WriteLine($"You only have {pinsStanding} pins to knock down!");
                    pins = PromptForPins(prompt);
                }
                currentFrame.Rolls.Add(new Roll(pins));

            }

            var score = theGame.GetScore();
            Console.Write($@"


******************************************************************

{Game.GetScoreMessage(score)}
Your score is {score} 

******************************************************************

"
            );

        }

        private static int PromptForPins(string prompt)
        {
            int pins;
            Console.WriteLine(prompt);


            if (!int.TryParse(Console.ReadLine(), out pins))
            {
                Console.WriteLine("Gotta be a number between 0 and 10.");
                return PromptForPins(prompt);
            }

            return pins;
        }

    }
}
