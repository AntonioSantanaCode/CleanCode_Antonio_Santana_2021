using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MooGameAntonioSantana.Games.Tests
{
    [TestClass()]
    public class BullAndCowGameTests
    {
        BullAndCowGame bullAndCowGame;

        [TestInitialize]
        public void Init()
        {
            bullAndCowGame = new();
        }

        [TestMethod()]
        public void MakeGoalTest()
        {
            int goal = bullAndCowGame.MakeGoal().Length;
            Assert.AreEqual(4, goal);
        }

        [TestMethod()]
        public void CheckBCTest()
        {
            string userGuess = "1234";
            string goal = "1234";
            string result = bullAndCowGame.CheckGuess(userGuess, goal);
            string bull = "BBBB";
            Assert.AreEqual(bull, result[..4]);
        }

        [TestMethod()]
        public void CheckBCAllWrongTest()
        {
            string userGuess = "1234";
            string goal = "5678";
            string result = bullAndCowGame.CheckGuess(userGuess, goal);
            string bull = ",";
            Assert.AreEqual(bull, result);
        }

        [TestMethod()]
        public void CheckCowTest()
        {
            string userGuess = "1234";
            string goal = "4321";
            string result = bullAndCowGame.CheckGuess(userGuess, goal);
            string bull = "CCCC";
            Assert.AreEqual(bull, result.Substring(1, 4));
        }
    }
}