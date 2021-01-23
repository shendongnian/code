	public class RestaurantTimingList
	{
		public List<RestaurantTiming> Timings { get; set; }
	
		public RestaurantTimingList()
		{
			Timings = new List<RestaurantTiming>();
	
			Timings.Add(new RestaurantTiming(1, DayOfWeek.Monday, "09:00", "18:00"));
			Timings.Add(new RestaurantTiming(2, DayOfWeek.Monday, "22:00", "02:00"));
	
			Timings.Add(new RestaurantTiming(3, DayOfWeek.Tuesday, "12:00", "23:59"));
	
			Timings.Add(new RestaurantTiming(4, DayOfWeek.Wednesday, "09:00", "18:00"));
			Timings.Add(new RestaurantTiming(5, DayOfWeek.Wednesday, "22:00", "02:00"));
	
			Timings.Add(new RestaurantTiming(6, DayOfWeek.Thursday, "14:00", "02:00"));
	
			Timings.Add(new RestaurantTiming(7, DayOfWeek.Friday, "16:00", "02:00"));
	
			Timings.Add(new RestaurantTiming(8, DayOfWeek.Saturday, "12:00", "01:00"));
	
			Timings.Add(new RestaurantTiming(9, DayOfWeek.Sunday, "12:00", "01:59"));
		}
	
		public bool CheckIsOpen(DayOfWeek weekDay, string time)
		{
			return Timings.Any(x=>x.IsMatch(weekDay, TimeSpan.Parse(time)));
		}
	
	}
