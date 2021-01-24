	public class Era
	{
		public string Name { get; set; }
	}
	public class Calendar
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int MinYear { get; set; }
		public int MaxYear { get; set; }
		public List<Era> Eras { get; set; }
	}
	public class Era2
	{
		public string Name { get; set; }
	}
	public class Date
	{
		public Calendar Calendar { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
		public int DayOfWeek { get; set; }
		public int YearOfEra { get; set; }
		public Era2 Era { get; set; }
		public int DayOfYear { get; set; }
	}
	public class RootObject
	{
		public Date Date { get; set; }
		public string AnotherProperty { get; set; }
	}
