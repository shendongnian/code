	static string[] MonthNames = new string[12]; // store the names of the month as found in the file to print out later
	static int GetMonthNumber(string month) {
		// Accommodating short month names and case sensitivity
		// TODO: handle locale issues for case and month names, if applicable
		var lowerMonth = month.ToLower();
		int value;
		if (lowerMonth.StartsWith("jan"))
			value = 0;
		else if (lowerMonth.StartsWith("feb"))
			value = 1;
		else if (lowerMonth.StartsWith("mar"))
			value = 2;
		else if (lowerMonth.StartsWith("apr"))
			value = 3;
		else if (lowerMonth.StartsWith("may"))
			value = 4;
		else if (lowerMonth.StartsWith("jun"))
			value = 5;
		else if (lowerMonth.StartsWith("jul"))
			value = 6;
		else if (lowerMonth.StartsWith("aug"))
			value = 7;
		else if (lowerMonth.StartsWith("sep"))
			value = 8;
		else if (lowerMonth.StartsWith("oct"))
			value = 9;
		else if (lowerMonth.StartsWith("nov"))
			value = 10;
		else if (lowerMonth.StartsWith("dec"))
			value = 11;
		else
			throw new ArgumentException($"Unknown month: {lowerMonth}", nameof(lowerMonth));
		MonthNames[value] = month;
		return value;
	}
	static void Main(string[] args) {
		Console.WriteLine("Unsorted Array:");
		
		string[] monArray = File.ReadAllLines("Month_1.txt"); /*new string[] { "January", "March", "January", "sept" };*/
		int[] monthNums = new int[11];
		for (int i = 0; i < monArray.Length; i++)
			Console.WriteLine(monArray[i]);
		foreach (string month in monArray)
			monthNums[GetMonthNumber(month)]++;
		for (int i = 0; i < monthNums.Length; i++) {
			if (monthNums[i] != 0)
				Console.WriteLine($"{MonthNames[i],-10} : ({monthNums[i]} times)");
		}
	}
