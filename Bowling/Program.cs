using System;
using Bowling.Models;
using Spectre.Console;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.MarkupLine("[bold yellow]Ready to Bowl?![/]");

            Game game = new Game();
            while (!game.IsComplete())
            {
                var currentFrame = game.GetCurrentFrame();

                var prompt = $"Frame {currentFrame.FrameNumber} Roll {currentFrame.Rolls?.Count + 1}; How many pins were knocked down?";
                var pins = PromptForPins(prompt, currentFrame.PinsStanding());

                currentFrame.Rolls.Add(new Roll(pins));
            }

            DisplayMessage(game.GetScore());
        }

        private static int PromptForPins(string prompt, int pinsStanding)
        {
            while (true)
            {
                var pins = AnsiConsole.Prompt(
                    new TextPrompt<int>("[aqua]" + prompt + "[/]")
                        .PromptStyle("green")
                        .ValidationErrorMessage("[red]Gotta be a number between 0 and " + pinsStanding + ".[/]")
                        .Validate(input =>
                        {
                            if (input < 0 || input > pinsStanding)
                                return ValidationResult.Error();
                            return ValidationResult.Success();
                        })
                );
                return pins;
            }
        }

        private static void DisplayMessage(int score)
        {
            var message = Game.GetScoreMessage(score);
            AnsiConsole.Write(new Rule("[yellow]Game Over[/]").RuleStyle("gold1"));
            AnsiConsole.MarkupLine($"[bold green]Your score is {score}[/]");
            AnsiConsole.MarkupLine($"[italic blue]{message}[/]");
            AnsiConsole.Write(new Rule());
        }
    }
}
