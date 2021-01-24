	string choice = string.Empty;
	// Ask something
	do
	{
	    Console.Clear();
	    Console.WriteLine("World is a Savage Machine, whatever you ask, it'll give you a nasty answer.");
	    Console.WriteLine("This is more a Joke, don't be sad if your Question isn't answered ;D");
	    Console.Write("\nAsk World something: ");
	    input = Console.ReadLine();
	} while (input == "");
	choice = input.split(" ")[0];
	switch (choice)
	{
	    case "Who":
	        Console.WriteLine("Question: Who cares?");
	        break;
		case "How":
	        Console.WriteLine("Kys. That's how.");
	        break;
