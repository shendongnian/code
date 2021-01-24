    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    public class Program
    {
    	public static void Main()
    	{
    		DateTime dt = new DateTime();
    		string userInput;
    		do
    		{
    			Console.Write("Please enter your birth date in YYYY.MM.DD format: ");
    			userInput = Console.ReadLine();
    		}
    		while (!DateTime.TryParseExact(userInput, "yyyy.MM.dd",
    									   CultureInfo.InvariantCulture,
    									   DateTimeStyles.None,
    									   out dt));
    		Console.WriteLine("You were born on:  \"{0}\"\n", dt.ToString("yyyy.MMMM.dd"));
    		Console.ReadLine();
    	}
    }
