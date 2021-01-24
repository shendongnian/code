	static void Main(string[] args)
	{
		int requiredMonths = 6;
		int weekDays = 7;
		DateTime date = new DateTime(2018, 2, 5);
		DateTime[] result = new DateTime[requiredMonths];            
		for (int i = 0; i < requiredMonths; i++)
		{
			DateTime firstDayOfNextMonth = date.AddMonths(i).AddDays(-date.Day + 1);
			for (int j = 0; j < weekDays; j++)
			{                    
				if (firstDayOfNextMonth.AddDays(j).DayOfWeek.Equals(DayOfWeek.Monday))
				{
					result[i] = firstDayOfNextMonth.AddDays(j);
				}                    
			}   
		}
		foreach (var item in result)
		{
			Console.WriteLine(item);
		}
	}
	
