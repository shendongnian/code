    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		DateTime date = DateTime.Now;
    		
    		var dateToday = " " + date.ToString("d");
    		var day = DateTime.Now.DayOfWeek;
    		var dayToday = " " + day.ToString();
    		
    		
    		if ((dayToday == DayOfWeek.Saturday.ToString()) && (dayToday == DayOfWeek.Sunday.ToString()))
    		{
    			Console.WriteLine(dayToday + " is a weekend");
    		} 
    		else 
    		{
    			Console.WriteLine(dayToday + " is not a weekend");
    		}
    	}
    }
