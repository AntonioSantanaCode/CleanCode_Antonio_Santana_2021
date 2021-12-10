using MooGameAntonioSantana.Interfaces;
using MooGameAntonioSantana.View;
using MooGameAntonioSantana.Controller;
using MooGameAntonioSantana.DAL;
using MooGameAntonioSantana.Model.Games;

namespace MooGameAntonioSantana
{
    class Program
	{
		public static void Main(string[] args)
        {
            IUserInterface ui = new ConsoleIO();
            IDataHandler dataHandler = new DataHandler();
            IBullAndCowGame game = new BullAndCowGame();
            IGuessLetterGame guessLetterGame = new GuessLetterGame();
            GameController controller = new(ui, dataHandler, game, guessLetterGame);
            controller.Run();
        }
    }
}