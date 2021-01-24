    using System.Linq;
    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		//Extract email
    		string a = "i:0#.f|membership|sdp950452@abctechnologies.com";
    	    string s = a.Split('|').Where(splitted => splitted.Contains("@")).FirstOrDefault().Split('@').First();
    		Console.WriteLine(s);		
    	
    		//Format Name
    		string name = "Pawar, Jaywardhan";
    		string formatted = String.Join(" ",name.Split(',').Reverse()).ToLower();
    		Console.WriteLine(formatted.TrimStart().TrimEnd());
    	}
    }
