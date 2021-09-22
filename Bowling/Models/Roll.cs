
namespace Bowling.Models
{
    public class Roll
    {
        public int PinsKnockedDown { get; set; }

        public Roll(int pins)
        {
            PinsKnockedDown = pins;
        }
    }
}
