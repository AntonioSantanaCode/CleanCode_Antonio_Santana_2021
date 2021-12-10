using MooGameAntonioSantana.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameAntonioSantana.Interfaces
{
    public interface IDataHandler
    {
        public void WriteToFile(string name, int guess, string gameName);
        public List<PlayerData> ReadFromFile();
    }
}
