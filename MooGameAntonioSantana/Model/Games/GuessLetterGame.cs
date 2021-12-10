using MooGameAntonioSantana.Interfaces;

namespace MooGameAntonioSantana.Model.Games
{
    public class GuessLetterGame : IGuessLetterGame
    {
        public string CheckGuess(string guess, string goal)
        {
            return guess.ToUpper() == goal ? "Good job!" : "Wrong letter try again!";
        }

        public string GenerateLetterGoal()
        {
            Random randomLetters = new();
            string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string goal;
            goal = letter[randomLetters.Next(26)].ToString();

            return goal;
        }
    }
}
