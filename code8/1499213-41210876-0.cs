    public static List<DateTime> GetDates(int year, int month,string day)
		{
		   return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
				.Where(d=>new DateTime(year, month, d).ToString("dddd").Equals(day))			
			   .Select(d => new DateTime(year, month, d)).ToList(); 
		}
