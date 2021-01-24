    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase) || choice.Equals("y", StringComparison.OrdinalIgnoreCase))
	{
		Console.Clear();
		startMeny();
	}
	else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase) || choice.Equals("n", StringComparison.OrdinalIgnoreCase))
	{
		Console.Clear();
		Console.WriteLine("Okay.. Bye!");
		Console.ReadKey();
	}
	else
	{
	  Console.WriteLine("Wrong Key");
	  Console.ReadLine();
	}
	break;
    case 2:
    	Console.WriteLine("Look it works!");
    	Console.ReadLine();
    	break;
    default:
    	Console.WriteLine("What?..");
    	Console.ReadLine();
    	return;
