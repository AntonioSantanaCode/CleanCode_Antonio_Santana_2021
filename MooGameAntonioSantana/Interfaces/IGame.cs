using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameAntonioSantana.Interfaces
{
    public interface IGame
    {
        public string MakeGoal();
        public string CheckGuess(string goal, string guess);
    }
}
