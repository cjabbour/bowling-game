using NUnit.Framework;
using Bowling.Models;
using System.Linq;

namespace Bowling.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void NewGame_ShouldHaveZeroScore()
        {
            var game = new Game();
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void GutterGame_ShouldScoreZero()
        {
            var game = CreateGameWithRolls(Enumerable.Repeat(0, 20).ToArray());
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void AllOnes_ShouldScoreTwenty()
        {
            var game = CreateGameWithRolls(Enumerable.Repeat(1, 20).ToArray());
            Assert.AreEqual(20, game.GetScore());
        }

        [Test]
        public void OneSpare_ShouldAddNextRollAsBonus()
        {
            var game = CreateGameWithRolls(new int[] {5,5,3}.Concat(Enumerable.Repeat(0,17)).ToArray());
            Assert.AreEqual(16, game.GetScore());
        }

        [Test]
        public void OneStrike_ShouldAddNextTwoRollsAsBonus()
        {
            var game = CreateGameWithRolls(new int[] {10,3,4}.Concat(Enumerable.Repeat(0,16)).ToArray());
            Assert.AreEqual(24, game.GetScore());
        }

        [Test]
        public void PerfectGame_ShouldScore300()
        {
            var game = CreateGameWithRolls(Enumerable.Repeat(10, 12).ToArray());
            Assert.AreEqual(300, game.GetScore());
        }

        private Game CreateGameWithRolls(int[] rolls)
        {
            var game = new Game();
            foreach (var pins in rolls)
            {
                var frame = game.GetCurrentFrame();
                frame.Rolls.Add(new Roll(pins));
            }
            return game;
        }
    }
}
