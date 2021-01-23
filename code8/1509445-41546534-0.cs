    public class DateTimeExtensions
    {
    	public static DateTime AddWorkHours(this DateTime dateTime, int workHours)
    	{
    		var workHoursPerday = 8; //Here 8 also can be configurable value if you have different working hours for different customer.
    		var daysToAdd = (int) workHours/workHoursPerday; //You can have validation here to check if workHours are in exact multiplex of 8. 
    		//Also you can have rounding off logic.
    		dateTime.AddDays(daysToAdd);
    	}
    }
