using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameAntonioSantana.Interfaces
{
    public interface IGuessLetterGame
    {
        public string CheckGuess(string guess, string goal);
        public string GenerateLetterGoal();
    }
}
