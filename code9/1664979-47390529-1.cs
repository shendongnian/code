	public static void Main(string[] args)
	{
		int cel = -1;
	
		while (cel < 73 || cel > 77)
		{
			Console.WriteLine();
			int fahrenheit = Ask("Skriv in temperaturen i Fahrenheit: ");
			cel = FahrenheitToCelsius(fahrenheit);
			if (cel > 77)
			{
				Console.WriteLine("This is too hot. Turn down the temperature.");
			}
			else if (cel < 73)
			{
				Console.WriteLine("This is too cold. Turn up the temperature");
			}
		}
	
		if (cel == 75)
		{
			Console.WriteLine("Perfect temperature!");
		}
		else
		{
			Console.WriteLine("Acceptable temperature.");
		}
	
		Console.ReadLine();
	}
