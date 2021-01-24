	if (counters > 1) {
		Console.WriteLine("You take " + counters + " counters.");
	}
	else if (counters > 0) // or if you rather counters == 1
	{
		Console.WriteLine("You take " + counters + " counter.");
	}
	else if (counters < 0)
	{
		Console.WriteLine("You give " + Math.Abs(counters) + " counters.");
	}
	else if (evenTotal == oddTotal)
	{
		Console.WriteLine("Even total is equal to odd total");
	}
	else
	{
		Console.WriteLine("No counters this game");
	}
