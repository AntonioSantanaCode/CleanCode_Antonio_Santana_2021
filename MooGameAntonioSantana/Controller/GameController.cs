using MooGameAntonioSantana.Interfaces;
using MooGameAntonioSantana.Model;
using MooGameAntonioSantana.Games;
using System;
using System.Collections.Generic;

namespace MooGameAntonioSantana.Controller
{
    public class GameController
    {
        private readonly IUserInterface _ui;
        private readonly IDataHandler _dataHandler;

        private readonly BullAndCowGame _bullAndCowGame;
        private readonly GuessLetterGame _guessLetterGame;

        private readonly List<PlayerData> scoreboard = new();

        private bool Running { get; set; }

        public GameController(IUserInterface ui, IDataHandler dataHandler, BullAndCowGame bullAndCowGame, GuessLetterGame guessLetterGame)
        {
            _ui = ui;
            _dataHandler = dataHandler;
            _bullAndCowGame = bullAndCowGame;
            _guessLetterGame = guessLetterGame;
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
                    GameBuilder(_bullAndCowGame);
                    break;
                case ConsoleKey.D2:
                    _ui.Clear();
                    GameBuilder(_guessLetterGame);
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
        private void PracticeAnswer(string answer)
        {
            _ui.UserOutput("Press 1 for practice mode or any other key to start.\n");

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    _ui.UserOutput($"For practice, answer is: {answer}\n");
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
                _ui.UserOutput(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
            }
        }
        private void GameBuilder(IGame _game)
        {
            string gameName = _game.GetType().Name;

            bool running = true;

            _ui.UserOutput("Enter your user name:\n");

            string name = _ui.UserInput();
            _ui.Clear();

            do
            {
                string goal = _game.MakeGoal();

                _ui.UserOutput("New game:\n");

                PracticeAnswer(goal);

                string guess = _ui.UserInput().ToUpper();

                int numberOfGuesses = 1;
                string result = _game.CheckGuess(goal, guess);
                _ui.UserOutput(result + "\n");

                while (guess != goal)
                {
                    numberOfGuesses++;
                    guess = _ui.UserInput().ToUpper();
                    _ui.UserOutput(guess + "\n");
                    result = _game.CheckGuess(goal, guess);
                    _ui.UserOutput(result + "\n");
                }

                _dataHandler.WriteToFile(name, numberOfGuesses, gameName);
                showTopList();
                _ui.UserOutput($"Correct, it took {numberOfGuesses} guesses\nContinue? Type [ y | n ] ");
                string answer = _ui.UserInput();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    running = false;
                }
            } while (running);
        }
    }
}
