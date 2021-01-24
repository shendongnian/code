	public class Deck : Hand
	{
		private static Random rand = new Random();
	
		public Deck() : base(
			from Suits s in Enum.GetValues(typeof(Suits))
			from Value v in Enum.GetValues(typeof(Value))
			orderby rand.Next()
			select new Card(s, v))
		{ }
	}
