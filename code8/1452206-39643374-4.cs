    private static Tuple<DateTime, DateTime> ParseDate(string dateTimes)
	{
		var split = dateTimes.Split(new[] { " to " }, StringSplitOptions.None);
		var time1 = DateTime.ParseExact(split[0], "h:mm tt",
											CultureInfo.InvariantCulture);
		var time2 = DateTime.ParseExact(split[1], "h:mm tt",
											CultureInfo.InvariantCulture);
	
		return Tuple.Create(time1, time2);
	}
	
	
	private static bool NotConflict(IEnumerable<string> times, string time) {
		var incTime = ParseDate(time);
		
		return !times.Any(t => {
			var parsed = ParseDate(t);
			
			
			return (incTime.Item1 > parsed.Item1 && incTime.Item1 < parsed.Item2) || (incTime.Item2 > parsed.Item1 && incTime.Item2 < parsed.Item2) || t == time;
		});
	}
	
	public static void Main()
	{
		var times = new List<string>();
		times.Add("6:00 PM to 9:00 PM");
		times.Add("10:00 AM to 1:00 PM");
		
		Console.WriteLine("No Conflict 5:00 PM to 7:00 PM: {0}", NotConflict(times, "5:00 PM to 7:00 PM"));
		Console.WriteLine("No Conflict 2:00 PM to 5:00 PM: {0}", NotConflict(times, "2:00 PM to 5:00 PM"));
	}
