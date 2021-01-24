	private static void CalculatePayDownDays(long payPerDay, long nationalDebt)
	{
		long days = nationalDebt / payPerDay;
		for (long i = 0; i < days; i++)
		{
			nationalDebt -= payPerDay;
			Console.WriteLine("Day {0}, New Balance: {1:c}", i, nationalDebt);
		}
	}
