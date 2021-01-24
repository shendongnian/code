    using System;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(IsIntegerRegex("")); // false
    		Console.WriteLine(IsIntegerRegex("2342342")); // true
    		
    		Console.WriteLine(IsInteger("1231231.12")); // false
    		Console.WriteLine(IsInteger("1231231")); // true
    		Console.WriteLine(IsInteger("1,231,231")); // true
    	}
    	
    	private static bool IsIntegerRegex(string value)
    	{
    		const string regex = @"^\d+$";
    		return Regex.IsMatch(value, regex);
    	}
    
    	private static bool IsInteger(string value)
    	{
    		var culture = CultureInfo.CurrentCulture;
    		const NumberStyles style = 
    			// NumberStyles.AllowDecimalPoint | 
    			// NumberStyles.AllowTrailingWhite | 
    			// NumberStyles.AllowLeadingWhite | 
    			// NumberStyles.AllowLeadingSign |
    			NumberStyles.AllowThousands;
    		
    		return Int64.TryParse(value, style, culture, out _);
    	}
    }
