    public interface IDateTimeNowProvider
    {
    	DateTime Now { get; }
    }
    
    public class DateTimeNowProvider : IDateTimeNowProvider
    {
    	public DateTime Now => DateTime.Now;
    }
