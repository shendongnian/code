	public class MatchDeck
	{
		private Random r = new Random();
		List<MatchCard> deck = null;
	
		public MatchDeck()
		{
			int[] number = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			string[] suits = { "R[]", "R0", "B0", "B[]" };
			deck = number.SelectMany(n => suits, (n, s) => new MatchCard(n, s)).ToList();
		}
	
		public void Shuffle()
		{
			deck = deck.OrderBy(x => r.Next()).ToList();
		}
	
		public void Deal()
		{
			List<MatchCard> player1 = deck.Where((x, n) => n % 2 == 0).ToList();
			List<MatchCard> player2 = deck.Where((x, n) => n % 1 == 0).ToList();
		}
	}
