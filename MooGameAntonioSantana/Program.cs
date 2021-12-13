using MooGameAntonioSantana.Interfaces;
using MooGameAntonioSantana.View;
using MooGameAntonioSantana.Controller;
using MooGameAntonioSantana.DAL;
using MooGameAntonioSantana.Games;

namespace MooGameAntonioSantana
{
    class Program
	{
		public static void Main(string[] args)
        {
            IUserInterface ui = new ConsoleIO();
            IDataHandler dataHandler = new DataHandler();
            var bullAndCow = new BullAndCowGame();
            var guessLetter = new GuessLetterGame();
            GameController controller = new(ui, dataHandler, bullAndCow, guessLetter);
            controller.Run();
        }
    }
}