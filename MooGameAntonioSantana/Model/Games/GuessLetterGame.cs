using MooGameAntonioSantana.Interfaces;

namespace MooGameAntonioSantana.Model.Games
{
    public class GuessLetterGame : IGame
    {
        public string CheckGuess(string guess, string goal)
        {
            return guess.ToUpper() == goal ? "Good job!" : "Wrong, try again!";
        }

        public string MakeGoal()
        {
            Random randomLetters = new();
            string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string goal;
            goal = letter[randomLetters.Next(26)].ToString();

            return goal;
        }
    }
}
