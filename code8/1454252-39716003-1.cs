    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		DateTime date = DateTime.Now;
    		
    		string dateToday = date.ToString("d");
    		DayOfWeek day = DateTime.Now.DayOfWeek;
    		string dayToday = day.ToString();
    		
    		// compare enums
    		if ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday))
    		{
    			Console.WriteLine(dateToday + " is a weekend");
    		}
    		else
    		{
    			Console.WriteLine(dateToday + " is not a weekend");
    		}
    		
    		// compare strings
    		if ((dayToday == DayOfWeek.Saturday.ToString()) || (dayToday == DayOfWeek.Sunday.ToString()))
    		{
    			Console.WriteLine(dateToday + " is a weekend");
    		}
    		else
    		{
    			Console.WriteLine(dateToday + " is not a weekend");
    		}
    	}
    }
