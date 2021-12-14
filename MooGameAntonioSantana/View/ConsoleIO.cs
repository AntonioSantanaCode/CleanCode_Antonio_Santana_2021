using MooGameAntonioSantana.Interfaces;
using System;

namespace MooGameAntonioSantana.View
{
    public class ConsoleIO : IUserInterface
    {
        void IUserInterface.Clear()
        {
            Console.Clear();
        }

        void IUserInterface.Exit()
        {
            Environment.Exit(0);
        }

        string IUserInterface.UserInput()
        {
            return Console.ReadLine().Trim();
        }
        void IUserInterface.UserOutput(string s)
        {
            Console.WriteLine(s);
        }
    }
}
