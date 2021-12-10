using MooGameAntonioSantana.Interfaces;
using MooGameAntonioSantana.Model;

namespace MooGameAntonioSantana.DAL
{
    public class DataHandler : IDataHandler
    {
        private StreamWriter _writer;
        private StreamReader _reader;

        private string GameName { get; set; }

        public List<PlayerData> ReadFromFile()
        {
            _reader = new($"{GameName}Result.txt");

            List<PlayerData> result = new List<PlayerData>();

            string line;

            while ((line = _reader.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);

                string name = nameAndScore[0];

                int guesses = Convert.ToInt32(nameAndScore[1]);

                PlayerData playerData = new PlayerData(name, guesses);

                int pos = result.IndexOf(playerData);

                if (pos < 0)
                {
                    result.Add(playerData);
                }
                else
                {
                    result[pos].Update(guesses);
                }
            }
            _reader.Close();
            result.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            return result;
        }
        public void WriteToFile(string name, int guess, string gameName)
        {
            GameName= gameName;
                _writer = new($"{GameName}Result.txt", append: true);
                _writer.WriteLine(name + "#&#" + guess);
                _writer.Close();
        }
    }
}
