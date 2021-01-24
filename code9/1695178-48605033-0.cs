        public static void Main(string[] args)
	{
		for (int mth = 1; mth <= 12; mth++)
		{
			DateTime dt = new DateTime(2010, mth, 1);
			while (dt.DayOfWeek != DayOfWeek.Monday)
			{
				dt = dt.AddDays(1);
			}
			Console.WriteLine(dt.ToLongDateString());
		}
		Console.ReadLine();
	}
