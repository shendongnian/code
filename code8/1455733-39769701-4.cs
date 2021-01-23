	public class RestaurantTiming
	{
		public int TimingId { get; set; }
		public Interval[] Intervals { get; set;}
		
		public string OpenTimeString { get; private set; }
		public string CloseTimeString { get; private set; }
	
		public RestaurantTiming(int timingId, DayOfWeek day, string openTime, string closeTime)
		{
			TimingId = timingId;
			OpenTimeString = openTime;
			CloseTimeString = closeTime;
			
			var intervals = new List<Interval>();
			
			
			var openTimeParsed = TimeSpan.Parse(openTime);		
			var closeTimeParsed = TimeSpan.Parse(closeTime);
	
			if (closeTimeParsed > openTimeParsed)
			{
				intervals.Add(new Interval() { Day = day, CloseTime = closeTimeParsed, OpenTime = openTimeParsed });
			}
			else
			{
				intervals.Add(new Interval() { Day = day, CloseTime = new TimeSpan(23,59,59), OpenTime = openTimeParsed });
				intervals.Add(new Interval() { Day = NextDayOfWeek(day), CloseTime = closeTimeParsed, OpenTime = new TimeSpan(0,0,0) });
			}		
			
			Intervals = intervals.ToArray();
		}
		
		public bool IsMatch(DayOfWeek day, TimeSpan span)
		{
			return Intervals.Any(x=>x.Day == day && x.OpenTime <= span && x.CloseTime >= span);
		}
	
		public class Interval
		{
			public DayOfWeek Day { get; set; }		
			public TimeSpan OpenTime { get; set; }		
			public TimeSpan CloseTime { get; set; }
		}
	
		private DayOfWeek NextDayOfWeek(DayOfWeek current)
		{
			return NextDays[current];
		}
	
		private static Dictionary<DayOfWeek, DayOfWeek> NextDays = new Dictionary<DayOfWeek, DayOfWeek>()
			{
				{DayOfWeek.Sunday, DayOfWeek.Monday},
				{ DayOfWeek.Monday, DayOfWeek.Tuesday},
				{ DayOfWeek.Tuesday, DayOfWeek.Wednesday},
				{ DayOfWeek.Wednesday, DayOfWeek.Thursday},
				{ DayOfWeek.Thursday, DayOfWeek.Friday},
				{ DayOfWeek.Friday, DayOfWeek.Saturday},
				{ DayOfWeek.Saturday, DayOfWeek.Sunday}
			};
	}
