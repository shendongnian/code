	class Player
	{
		public string Name {get;set;}
		public decimal Balance {get;set;}
		public List<Card> Cards {get;set;}
		
		public void ViewCards()
		{
			foreach (var card in Cards)
			{
				Console.WriteLine($"{card.Name}");
				Console.WriteLine($"Attack: {card.Attack}");
				Console.WriteLine($"Defense: {card.Defense}");
				Console.WriteLine($"Cost: ${card.Cost}");
			}    
		}
	}
