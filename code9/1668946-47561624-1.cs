	private static void CalculatePayDownDays(long payPerDay, long nationalDebt)
	{
		long days = (long)Math.Ceiling((decimal)nationalDebt / payPerDay);
				
		for (long i = 1; i < days + 1; i++)
		{
			nationalDebt -= payPerDay;
			Console.WriteLine("Day {0}, New Balance: {1:c}", i, nationalDebt);
		}
	}
