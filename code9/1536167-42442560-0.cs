        using System;
    using System.Globalization;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var result = GetRecordTime("05 . 02. 2017 / 04 : 01 : 55 . 056");
    		Console.WriteLine(result);
    	}
    	
    	static DateTime GetRecordTime(string input) 
    	{
    	  return DateTime.ParseExact(input, "dd . MM. yyyy / HH : mm : ss . fff", CultureInfo.InvariantCulture);
    	}
    }
