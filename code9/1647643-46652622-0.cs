    using System;
    using System.Text.RegularExpressions;
     
    public class Test
    {
    	public static void Main()
    	{
    		string txt = "~A.~ ( tilde, then any single upper case letter, then dot, then tilde)";
    		string pattern = "~([A-Z])\\.~";
    		string replacement = "~$1\u2006~";
    		Regex rx = new Regex(pattern);
    		string result = rx.Replace(txt, replacement);
    		Console.WriteLine("Replacement String: {0}", result);                             
    	}
    }
