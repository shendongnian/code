    private static List<int> _denominations = new List<int>() { 1000, 5000 };
	private static int _denominationMin = _denominations[0];
	static void Main()
	{
		bool roundDown = false;
		
		Console.WriteLine("Enter number: ");
		int input = Convert.ToInt32(Console.ReadLine());
		if(roundDown)
		{
			for(int i = input; i > _denominationMin; i--)
			{
				if(Check(0,0,i))
				{
					Console.WriteLine("Number: {0}", i);
					break;
				}
			}
		}
		else
		{
			for (int i = input; i < int.MaxValue; i++)
			{
				if (Check(0, 0, i))
				{
					Console.WriteLine("Number: {0}", i);
					break;
				}
			}
		}
		Console.Read();
	}
	static bool Check(int highest, int sum, int goal)
	{
		//Bingo!
		if (sum == goal)
		{
			return true;
		}
		//Oops! exceeded here
		if (sum > goal)
		{
			return false;
		}
		
		// Loop through _denominations.
		foreach (int value in _denominations)
		{
			// Add higher or equal amounts.
			if (value >= highest)
			{
				if(Check(value, sum + value, goal))
				{
					return true;
				}
			}
		}
		return false;
	}
