	public void TestScore()
	{
		string input = Console.ReadLine();
		int score;
		
		if (int.TryParse(input, out score))
		{
			if (score >= 300 && score <= 850)
			{
				Console.WriteLine("The score passes.");
			}
			else
			{
				Console.WriteLine("The score fails.");
			}
		}
		else
		{
			Console.WriteLine("The score is not in the correct format.");
		}
	}
