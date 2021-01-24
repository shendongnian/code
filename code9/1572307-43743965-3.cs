    public class DateTimeInterval
    {
    	public DateTime? From { get; set; }
    	public DateTime? To { get; set; }
    }
    
    public static class DateTimeUtils
    {
    	public static DateTimeInterval GetIntervalIntersection(DateTimeInterval testInterval, DateTimeInterval allowedInterval)
    	{
    		if (testInterval.From.Value < allowedInterval.From.Value && testInterval.To.Value < allowedInterval.From.Value
    			|| testInterval.From.Value > allowedInterval.To.Value && testInterval.To.Value > allowedInterval.To.Value)
    		{
    			return new DateTimeInterval();
    		}
    
    		DateTime from = testInterval.From < allowedInterval.From
    			? allowedInterval.From.Value
    			: testInterval.From.Value;
    
    		DateTime to = testInterval.To > allowedInterval.To
    			? allowedInterval.To.Value
    			: testInterval.To.Value;
    
    		var result = new DateTimeInterval
    		{
    			From = from,
    			To = to
    		};
    
    		return result;
    	}
    }
