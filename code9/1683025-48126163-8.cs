	public static void Main()
	{
		Random p1rnd = new Random();
        List<string> p1list = new List<string>
		{
			"When you make the sentences letters, nobody can understand your example.",
			"But I think you mean for the user to pick from several sentences.",
			"Once a sentence is spoken, it can't be spoken again.",
			"The user can then pick from the two remaining sentences or pick a new, third sentence.",
			"This goes on until he gets tired of it or you run out of sentences.",
			"They use this sort of system in some RPGs."
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
