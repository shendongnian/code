    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
	        Regex regex = new Regex(@"\d+");
	        Match match = regex.Match("Dot 55 Perls");
	        if (match.Success)
	        {
	            Console.WriteLine(match.Value);
	        }
        }
    }
