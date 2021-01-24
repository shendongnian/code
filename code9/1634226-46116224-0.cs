	Console.WriteLine("How many times should the dice be rolled ?");
	int numberOfRolledTimes = int.Parse(Console.ReadLine());
	var diceRandom = new Random();
	var numberAndTimesArray = new int[6];
	for (int i = 0; i < numberOfRolledTimes; i++)
	{
		var rolledResult = diceRandom.Next(1, 7);
		numberAndTimesArray[rolledResult - 1]++;
	}
	for (int i = 0; i < 6; i++)
	{
		double precentage = 100.0*numberAndTimesArray[i] / numberOfRolledTimes*1.0;
		Console.WriteLine("Dice result of {0} rolled {1} times. ({2}%)", i + 1, numberAndTimesArray[i], precentage);
	}
