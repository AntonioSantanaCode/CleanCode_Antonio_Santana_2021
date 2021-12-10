using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameAntonioSantana.Interfaces
{
    public interface IBullAndCowGame
    {
        public string MakeGoal();
        public string CheckBC(string goal, string guess);
    }
}
