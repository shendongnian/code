    using System;
    public class Program
    {
    	public static void Main()
    	{
    		DateTime? dt = null;
    		
    		do
    		{ 
    			Console.WriteLine("Input date: (dd/MM/yyyy)");
    			var input = Console.ReadLine();
    		
    			try
    			{
    				dt = DateTime.ParseExact(input, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    			}
    			catch(Exception ex)
    			{
    				Console.WriteLine(ex.Message);
    		 	}
    		} while (!dt.HasValue);
    		
    		Console.WriteLine(dt.Value.ToString("F"));
    	}
    }
