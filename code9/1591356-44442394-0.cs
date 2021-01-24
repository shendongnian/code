    using System;
    using System.Globalization;
    
    public class Program
    {
    	public static void Main()
    	{
    		var input = "12/10/2012, 12/15/2015";
    		String[] dates = input.Split(',');
    
    		if(dates.Length != 2){
    			Console.WriteLine("I said 2 dates");
    		} else {
    			foreach (var date in dates)
    			{
    				DateTime parsedDate;
    				if(DateTime.TryParse(date, new CultureInfo("es"), DateTimeStyles.None, out parsedDate))
    				{
    					Console.WriteLine("{0} Perfect!", parsedDate);
    				}
    				else 
    				{
    					Console.WriteLine("{0} Not right sir!", date);
    				}
    			}
    		}
            
            Console.ReadLine();
    	}
    }
