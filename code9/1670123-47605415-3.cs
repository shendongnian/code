    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var regex = new Regex("(\uD82F[\uDCA0-\uDCA3])");
    		Console.WriteLine(regex.Match("\uD82F\uDCA2").Success);
    	}
    }
