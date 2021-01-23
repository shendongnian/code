    		List<DateTime> datelist = new List<DateTime>();
			int balanceday = 1;
			while (datelist.Count < 10)
			{
				DateTime day = DateTime.Now.AddDays(balanceday + datelist.Count).Date;
				if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
				{
					datelist.Add(day);
				}
				else
				{
					balanceday++;
				}
			}
