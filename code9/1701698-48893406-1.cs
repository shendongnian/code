	public class Program
	{
		static public List<TimeSheetLog> testData = new List<TimeSheetLog>
		{
			new TimeSheetLog
			{
				ClockInTimeStamp = DateTime.Parse("1/1/2018 9:00 am"),
				ClockOutTimeStamp = DateTime.Parse("1/1/2018 5:00 pm")
	
			},
			new TimeSheetLog
			{
				ClockInTimeStamp = DateTime.Parse("1/2/2018 9:00 am"),
				ClockOutTimeStamp = DateTime.Parse("1/2/2018 5:00 pm")
	
			},
			new TimeSheetLog
			{
				ClockInTimeStamp = DateTime.Parse("1/31/2018 6:00 pm"),
				ClockOutTimeStamp = DateTime.Parse("2/1/2018 9:00 am")
	
			},
			new TimeSheetLog
			{
				ClockInTimeStamp = DateTime.Parse("2/3/2018 9:00 am"),
				ClockOutTimeStamp = DateTime.Parse("2/3/2018 5:00 pm")
	
			}
		};
		
		
		public static void Main()
		{
			var startPeriod = new DateTime(2018, 1, 1);
			var endPeriod = new DateTime(2018, 1, 31, 23, 59, 59, 9999); 
			Console.WriteLine( testData.TotalMinutes(startPeriod, endPeriod).ToString("0.00") );
		}
	}
