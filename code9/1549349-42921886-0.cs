	var number =3;
	do{
		Console.WriteLine("Give a number");
		string w=Console.ReadLine();
		try
		{
			double d = Convert.ToDouble(w);
		}
		catch(FormatException)
		{
			Console.WriteLine("it is not a number");
			continue; // not a number starting new iteration of the loop
		}
		double dd=Convert.ToDouble(w);
		if (dd == number)
		{
			Console.WriteLine("Yes, it is!");
			break; // The number guessed exiting loop
		}
		else if (dd>number)
		{
			Console.WriteLine("to big number");
		}
		else if(dd<number)
		{
			Console.WriteLine("to small number");
		}
	}
	while (true);
	Console.ReadLine();
