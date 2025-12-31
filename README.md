# Bowling Game

A simple console application that simulates a ten-pin bowling game, built with .NET 10.

## Features

- Interactive command-line gameplay for a single player
- Accurate scoring for strikes, spares, and open frames
- Fun feedback messages based on your final score
- Modular code structure with clear separation of game logic

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later

### Build and Run

1. Clone the repository:
    ```sh
    git clone https://github.com/cjabbour/bowling-game.git
    cd bowling-game
    ```

2. Build the project:
    ```sh
    dotnet build Bowling/Bowling.csproj
    ```

3. Run the game:
    ```sh
    dotnet run --project Bowling/Bowling.csproj
    ```

### How to Play

- The game will prompt you for the number of pins knocked down in each roll.
- Enter a number between 0 and the number of pins standing.
- The game continues for 10 frames, handling strikes and spares according to standard bowling rules.
- At the end, your total score and a feedback message will be displayed.

## Project Structure

```
Bowling/
??? Models/
?   ??? Frame.cs   # Represents a single frame in the game
?   ??? Game.cs    # Manages game state and scoring
?   ??? Roll.cs    # Represents a single roll
??? Extensions.cs  # Utility extension methods
??? Program.cs     # Main entry point and user interaction
??? Bowling.csproj # Project file
Bowling.Tests/
??? GameTests.cs   # NUnit tests for game logic
??? Bowling.Tests.csproj # Test project file
```

## Testing

Unit tests are provided in the `Bowling.Tests` project using [NUnit](https://nunit.org/).

### Running Tests

1. Build the solution (if not already built):
    ```sh
    dotnet build
    ```
2. Run the tests:
    ```sh
    dotnet test Bowling.Tests/Bowling.Tests.csproj
    ```

The tests cover scenarios such as:
- New game score
- Gutter game
- All ones
- Spares and strikes
- Perfect game

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements.

## License

This project is licensed under the MIT License.
