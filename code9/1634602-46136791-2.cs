	public class Hand : List<Card>
	{
		public Hand(IEnumerable<Card> cards)
		{
			this.AddRange(cards);
		}
		
		public IEnumerable<int> Values()
		{
			return ComputeValues(this.ToArray());
		}
		
		private IEnumerable<int> ComputeValues(Card[] cards)
		{
			if (cards.Length == 0)
			{
				return Enumerable.Empty<int>();
			}
			else if (cards.Length == 1)
			{
				return cards[0].Values();
			}
			else
			{
				return
					cards[0]
						.Values()
						.SelectMany(
							v => ComputeValues(cards.Skip(1).ToArray()),
							(v, n) => v + n)
						.Distinct();
			}
		}
	}
