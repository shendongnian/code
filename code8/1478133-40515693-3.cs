    using System;
					
    public class Program
    {
	    public static void Main()
	    {
		    string stringToSplit = "NHRM__Location__c"; // 2 underscores in each location
		    char[] sep = new char[] {'_', '_'};
		    string newString = stringToSplit.Split(sep)[2];
		    Console.WriteLine(newString);
	    }
    }
