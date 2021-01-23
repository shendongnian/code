	action:
		Console.WriteLine("what do you want to do");
		string actionAnswer = Console.ReadLine();
		if((actionAnswer == "look") || (actionAnswer == "inspect") || (actionAnswer == "lookAround"))
		{
			goto inspectSuroundings;
		}
		else if((actionAnswer == "inspectKey") || (actionAnswer == "lookAtKey"))
		{
			goto inspectKey;
		}
		else if((actionAnswer == "inspectDoor") || (actionAnswer == "lookAtDoor"))
		{
			goto inspectDoor;
		}
		else
		{
			Console.Beep();
			goto action;
		}
	inspectSuroundings:
		Console.WriteLine("You see a small white room with a large two pronged key and a door.");
		goto action;
	inspectKey:
		Console.WriteLine("It seems to be a large gold key,with three prongs instead of two.");
		goto action;
	inspectDoor:
		Console.WriteLine("Its locked.There mus be a THREE PRONGED key around here.");
		goto action;
