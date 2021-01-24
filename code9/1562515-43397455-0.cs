	public void roll()
	{
		 this.Roles = Enumerable.Range(1, 5)
                                .Select(i => RandomNumGenerator.Next(1, 6))
                                .ToList();
		// Check for three of a kind:
		bool threeOfAKind = this.Roles.GroupBy(i => i).Any(g => g.Count() >= 3);
		// rest of your logic
	    Console.WriteLine("\tTotal score = {0}", threepoints);
	}
