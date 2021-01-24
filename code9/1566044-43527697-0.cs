	case 3:
		Console.WriteLine("\n************************************");
		Console.WriteLine("Skriv in ett ord du vill söka efter i loggboken:");
		string nyckelord = Console.ReadLine();//Här sparas inmatningen av nyckelordet
		bool found = false;
		foreach (string[] item in loggbok)
		{
			if (item.Any(l => l.Contains(nyckelord))
			{
				found = true;
				Console.WriteLine(item[0]);
				Console.WriteLine(item[1]);
				Console.WriteLine();
			}
		}
		if (!found)
		{
			Console.WriteLine("finns inte");
		}
		break;
