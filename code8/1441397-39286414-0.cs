    public class DateTimeRangeObject
    {
    	public DateTime Date1 {get; set;}
    	public DateTime Date2 {get; set;}
    	
    	public static DateTimeRangeObject Parse(string input)
    	{
    		var matches = Regex.Matches(inputStr, "\\d{2}\\/\\d{2}");
    		
    		return new DateTimeRangeObject
    		{
    			Date1 = DateTime.ParseExact(matches[0].Value, "MM/dd", null),
    			Date2 = DateTime.ParseExact(matches[1].Value, "MM/dd", null)
    		};
    	}
    }
