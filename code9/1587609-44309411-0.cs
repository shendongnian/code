	interface ICustomResolver
	{
		DateTime AddMinutes(DateTime, int);
	}
	
	public class DbCustomResolver : ICustomResolver
	{
		public DateTime AddMinutes(DateTime time, int minutes)
		{
			return DbFunctions.AddMinutes(time, minutes);
		}
	}
	
	public class NonDbCustomResolver : ICustomResolver
	{
		public DateTime AddMinutes(DateTime time, int minutes)
		{
			return time.AddMinutes(minutes);
		}
	}
	
	
	ICustomResolver MyCustomResolver = 
       amIUsingDB ? new DbCustomResolver() : new NonDbCustomResolver();
	
