

namespace MooGameAntonioSantana.Interfaces
{
    public interface IGame
    {
        public string MakeGoal();
        public string CheckGuess(string goal, string guess);
    }
}
