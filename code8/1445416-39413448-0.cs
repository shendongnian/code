    using System;
					
    public class Program
    {
	    public static void Main()
	    {
		    var s = RandomDigits(5);
		
		    Console.WriteLine(s);
	    }
	
	    public static string RandomDigits(int length)
        {
		    char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
			
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, alphabet[random.Next(0,26)] +" ");
            return s;
        }
    }
