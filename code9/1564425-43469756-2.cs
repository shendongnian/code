	Console.WriteLine("De originele opsteling van nummers:");
	Console.Write(string.Join("    ", userInts));
	Console.WriteLine();
	userInts.Sort();
	Console.WriteLine("Lijst in gesorteerde ordening:");
	Console.Write(string.Join("    ", userInts));
	Console.WriteLine();
	Console.ReadKey();
