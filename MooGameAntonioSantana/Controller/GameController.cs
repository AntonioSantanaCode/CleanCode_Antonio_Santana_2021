using MooGameAntonioSantana.Interfaces;
using MooGameAntonioSantana.Model;

namespace MooGameAntonioSantana.Controller
{
    public class GameController
    {
        private readonly IUserInterface _ui;
        private readonly IDataHandler _dataHandler;
        private readonly IGame _game;

        private readonly List<PlayerData> scoreboard = new();

        private bool Running { get; set; }

        public GameController(IUserInterface ui, IDataHandler dataHandler, IGame game)
        {
            _ui = ui;
            _dataHandler = dataHandler;
            _game = game;
        }
        public void Run()
        {
            do
            {
                GameMenu();
            } while (!Running);
        }

        private void GameMenu()
        {
            _ui.UserOutput("\t_________________________________");
            _ui.UserOutput("\n\t -- Choose your game --");
            _ui.UserOutput("\n\t1. Bull and cow game.");
            _ui.UserOutput("\t2. Guess the letter game.");
            _ui.UserOutput("\n\t   Press ESC to close the app.");
            _ui.UserOutput("\t_________________________________");

            UserMenuChoice();
        }
        private void UserMenuChoice()
        {
            Running = true;
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    _ui.Clear();
                    BullAndCowGame();
                    break;
                case ConsoleKey.D2:
                    _ui.Clear();
                    GuessLetterGame();
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    Running = false;
                    _ui.Clear();
                    _ui.UserOutput("Invalid input.\n");
                    break;
            }
        }
        private void PracticeAnswer(string goal)
        {
            _ui.UserOutput("Press 1 for practice mode or any other key to start.\n");

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    _ui.UserOutput($"For practice, answer is: {goal}\n");
                    break;
                default:
                    _ui.UserOutput($"Good luck!\n");
                    break;
            }

        }
        private void showTopList()
        {
            scoreboard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            _ui.UserOutput("Player   games average");
            foreach (PlayerData p in _dataHandler.ReadFromFile())
            {
                _ui.UserOutput(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
        }

        // Games
        private void BullAndCowGame()
        {
            string gameName = _game.GetType().Name;
            bool running = true;
            _ui.UserOutput("Welcome to Bull and cow game! \nEnter your user name:\n");
            string name = _ui.UserInput();
            _ui.Clear();

            do
            {
                string goal = _game.MakeGoal();

                _ui.UserOutput("New game:\n");

                PracticeAnswer(goal);

                string guess = _ui.UserInput();

                int nGuess = 1;
                string bbcc = _game.CheckGuess(goal, guess);
                _ui.UserOutput(bbcc + "\n");

                while (bbcc != "BBBB,")
                {
                    nGuess++;
                    guess = _ui.UserInput();
                    _ui.UserOutput(guess + "\n");
                    bbcc = _game.CheckGuess(goal, guess);
                    _ui.UserOutput(bbcc + "\n");
                }

                _dataHandler.WriteToFile(name, nGuess, gameName);
                showTopList();
                _ui.UserOutput($"Correct, it took {nGuess} guesses\nContinue?");
                string answer = _ui.UserInput();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    running = false;
                }
            } while (running);
        }
        private void GuessLetterGame()
        {
            string gameName = _game.GetType().Name;
            bool running = true;
            _ui.UserOutput("Welcome to Guess the Letter! \nEnter your user name:\n");
            string name = _ui.UserInput();

            do
            {
                string goal = _game.MakeGoal();

                _ui.UserOutput("New game:\n");

                PracticeAnswer(goal);

                string guess = _ui.UserInput().ToUpper();

                int nGuess = 1;

                _ui.UserOutput($"{_game.CheckGuess(guess, goal)}");

                while (guess != goal)
                {
                    nGuess++;
                    guess = _ui.UserInput().ToUpper();
                    _ui.UserOutput(guess + "\n");
                }

                _dataHandler.WriteToFile(name, nGuess, gameName);
                showTopList();
                _ui.UserOutput($"Correct, it took {nGuess} guesses\nContinue?");
                string answer = _ui.UserInput();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    running = false;
                }
            } while (running);
        }

    }
}
