	public static double ReadInput()
	{
		double number;
		while (!AssertIsDouble(Console.ReadLine(), out number))
		{
			Console.WriteLine("Please, input a number greater than zero (0).");
		}
        return number;
	}
	public bool AssertIsDouble(string input, out double number)
	{
		return (Double.TryParse(input, out number) && number > 0);
	}
