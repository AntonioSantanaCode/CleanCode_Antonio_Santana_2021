using MooGameAntonioSantana.Interfaces;

namespace MooGameAntonioSantana.Model
{
    public class PlayerData
	{
		public string Name { get; private set; }
		public int NGames { get; private set; }
        public int TotalGuesses { get; set; }


		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NGames = 1;
			TotalGuesses = guesses;
		}

		public void Update(int guesses)
		{
			TotalGuesses += guesses;
			NGames++;
		}

		public double Average()
		{
			return (double)TotalGuesses / NGames;
		}


		public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}


		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
