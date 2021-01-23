    using System;
					
    public class Program
    {
	    public static void Main()
	    {
		    string stringToSplit = "NHRM_Location_c";
		    string newString = stringToSplit.Split('_')[1];
		    Console.WriteLine(newString);
	    }
    }
