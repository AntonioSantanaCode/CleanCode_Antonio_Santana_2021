using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameAntonioSantana.Interfaces
{
    public interface IUserInterface
    {
        public void Clear();
        public void Exit();
        public string UserInput();
        public void UserOutput(string s);
    }
}
