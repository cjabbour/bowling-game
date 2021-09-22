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

        public int PinCount() => Rolls.Select(r => r.Pins).Sum();

        public bool IsComplete()
        {
            if (Rolls.Count == MaxRollCount()) return true;
            
            if (FrameNumber < 10) return PinCount() == 10;

            if (FrameNumber == 10 && Rolls.Count == 2 && PinCount() < 10) return true;
            
            return false;
        }

        public bool IsStrike()
        {
            return Rolls?.Count == 1 && PinCount() == 10;
        }

        public bool IsSpare()
        {
            return Rolls?.Count == MaxRollCount() && PinCount() == 10;
        }
    }
}
