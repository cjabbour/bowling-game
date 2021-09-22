using System.Collections.Generic;
using System.Linq;

namespace Bowling.Models
{
    public class Frame
    {
        public List<Roll> Rolls { get; set; }
        public int FrameNumber { get; set; }

        public Frame(int frameNumber)
        {
            FrameNumber = frameNumber;
            Rolls = new List<Roll>();
        }

        private int MaxRollCount() => FrameNumber == 10 ? 3 : 2;

        public int PinsKnockedDown() => Rolls.Select(r => r.PinsKnockedDown).Sum();

        public int PinsStanding()
        {
            if (FrameNumber == 10)
            {
                if (Rolls.Count == 1 && PinsKnockedDown() == 10) return 10; // 2nd roll, 1st was strike, start fresh
                if (Rolls.Count == 2) return 10 - (PinsKnockedDown() % 10);        // 3rd roll, always start fresh

            }
            return 10 - PinsKnockedDown();
        }

        public bool IsComplete()
        {
            if (Rolls.Count == MaxRollCount()) return true;
            
            if (FrameNumber < 10) return PinsKnockedDown() == 10;

            if (FrameNumber == 10 && Rolls.Count == 2 && PinsKnockedDown() < 10) return true;
            
            return false;
        }

        public bool IsStrike()
        {
            return Rolls?.Count == 1 && PinsKnockedDown() == 10;
        }

        public bool IsSpare()
        {
            return Rolls?.Count == MaxRollCount() && PinsKnockedDown() == 10;
        }
    }
}
