using MooGameAntonioSantana.Model;
using System.Collections.Generic;

namespace MooGameAntonioSantana.Interfaces
{
    public interface IDataHandler
    {
        public void WriteToFile(string name, int guess, string gameName);
        public List<PlayerData> ReadFromFile();
    }
}
