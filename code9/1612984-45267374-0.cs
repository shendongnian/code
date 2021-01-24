    int userNumber = 0; // assign a value in order to be able to use the variable
	int.TryParse(userNumberstring, out userNumber);
		
	while (userNumber != randomNumber)
	{
		if (userNumber < 0 || userNumber > 100) 
        {
			Console.WriteLine("out of range");
		}
		else if (userNumber < randomNumber) {
			Console.WriteLine("too small");
		}
		else if (userNumber > randomNumber) {
			Console.WriteLine("too big");
		}
		else 
        {
			Console.WriteLine("bug");
		}
			Console.WriteLine("number between 0 and 100 ?");
			userNumber = Int32.Parse(Console.ReadLine()); // reuse variable
		}
	Console.WriteLine("great");
