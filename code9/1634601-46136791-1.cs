	public class Card
	{
		public Card(Suits suit, Value value)
		{
			this.Value = value;
			this.Suit = suit;
		}
	
		public Value Value { get; private set; }
		public Suits Suit { get; private set; }
	
		public IEnumerable<int> Values()
		{
			yield return (int)this.Value < 10 ? (int)this.Value : 10;
			if (this.Value == Value.Ace)
			{
				yield return 11;
			}
		}
	
		public override String ToString()
		{
			return String.Format("{0} {1}", this.Value, this.Suit);
		}
	}
