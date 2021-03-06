using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MooGameAntonioSantana.Games.Tests
{
    [TestClass()]
    public class GuessLetterGameTests
    {
        GuessLetterGame guessLetterGame;

        [TestInitialize]
        public void Init()
        {
            guessLetterGame = new();
        }

        [TestMethod()]
        public void CheckGuessTest()
        {
            string userGuess = "a";
            string goal = "A";

            string result = guessLetterGame.CheckGuess(userGuess,goal);
            string answer = "Good job!";
            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void CheckGuessWrongLetterTest()
        {
            string userGuess = "b";
            string goal = "A";

            string result = guessLetterGame.CheckGuess(userGuess, goal);
            string answer = "Wrong, try again!";
            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void GenerateLetterGoalTest()
        {
            int goal = guessLetterGame.MakeGoal().Length;
            Assert.AreEqual(1, goal);
        }
    }
}