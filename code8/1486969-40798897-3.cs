	while(true)
	{
		Console.WriteLine("what do you want to do");
		string actionAnswer = Console.ReadLine();
		if((actionAnswer == "look") || (actionAnswer == "inspect") || (actionAnswer == "lookAround"))
		{
			Console.WriteLine("You see a small white room with a large two pronged key and a door.");
		}
		else if((actionAnswer == "inspectKey") || (actionAnswer == "lookAtKey"))
		{
			Console.WriteLine("It seems to be a large gold key,with three prongs instead of two.");
		}
		else if((actionAnswer == "inspectDoor") || (actionAnswer == "lookAtDoor"))
		{
			Console.WriteLine("Its locked.There mus be a THREE PRONGED key around here.");
		}
		else
		{
			Console.Beep();
		}
	}
