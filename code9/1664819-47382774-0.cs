    using System;
					
    public class Program
    {
	    public static void Main()
	    {
		    string BadLetters = "qwertyuiopasdfghjklzxcvbnm";
            string password = "Blablauio";
            Console.WriteLine(password.IndexOf(BadLetters.Substring(0,3))>=0?"Present":"Not Present");
            Console.ReadLine();
	    }
    }
