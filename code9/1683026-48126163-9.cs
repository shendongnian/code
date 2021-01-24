		var choiceLetters = new [] { "A", "B", "C" };
		
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
