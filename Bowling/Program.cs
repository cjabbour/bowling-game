using System;
using Bowling.Models;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready to Bowl?!");

            Game game = new Game();
            while (!game.IsComplete())
            {
                var currentFrame = game.GetCurrentFrame();

                var prompt = $"Frame {currentFrame.FrameNumber} Roll {currentFrame.Rolls?.Count + 1}; How may pins were knocked down?";
                var pins = PromptForPins(prompt);

                while (pins > (currentFrame.PinsStanding()) || pins < 0)
                {
                    Console.WriteLine($"You only have {currentFrame.PinsStanding()} pins to knock down!");
                    pins = PromptForPins(prompt);
                }
                currentFrame.Rolls.Add(new Roll(pins));
            }

            DisplayMessage(game.GetScore());
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

        private static void DisplayMessage(int score)
        {
            Console.Write($@"


******************************************************************

{Game.GetScoreMessage(score)}
Your score is {score} 

******************************************************************

"
            );
        }

    }
}
