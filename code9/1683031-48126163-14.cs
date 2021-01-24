	public static void Main()
	{
		Random p1rnd = new Random();
        List<string> p1list = new List<string>
		{
			"These sentences make up the random list of choices.",
			"In your example you used single letters.",
			"That was kind of confusing.",
			"The user always sees A, B, and C.",
			"But not sentences 0, 1, and 2.",
			"I'll have a beer please."
		};
		
	    var sortedList = p1list.OrderBy( s => p1rnd.NextDouble() ).ToList();
		var choiceLetters = new [] { "A", "B", "C" };
		
		while (true)
		{
			var choiceStrings = choiceLetters.Zip
			(
				sortedList, 
				(a,b) => string.Format("{0}. {1}", a, b)
			);
		
			Console.WriteLine("What would you like to say?");
			foreach (var s in choiceStrings) 
			{
				Console.WriteLine(s);
			}
		
			var choiceLetter = Console.ReadLine();
			var choiceIndex = Array.IndexOf(choiceLetters, choiceLetter.ToUpper());
			if (choiceIndex == -1) break;  //User didn't pick A, B, or C
			
			sortedList.RemoveAt(choiceIndex);
		}
	}
