    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<string> aList = new List<string>()
    		{"hey hello how are you ok", "how are you", "are you", "you", "how you are ok you", "howareyou", "howok", "how you", "hey hello"};
    		
    		
    		var input = "hello how are you";
    		
    		// build matcher
    		string[] chunks = input.Split(' ');
    		string matcher = "";
    		for (int i = chunks.Length, j = 0; i > 1; i--, j++){
    			var matcherPart = new string [i];
    			Array.Copy(chunks, j, matcherPart, 0, i);
    			matcher += "("+String.Join(@"+\s+", matcherPart) + ")";
    		}
    		matcher = matcher.Replace(")(", ")|(");
    		
    		// Console.WriteLine(matcher);
    		//(hello+\s+how+\s+are+\s+you)|(how+\s+are+\s+you)|(are+\s+you)";
    		
    		
    		foreach (string a in aList)
    		{
    			Regex r = new Regex(matcher, RegexOptions.IgnoreCase);
    			Match m = r.Match(a);
    			Group g = m.Groups[0];
    			Console.WriteLine(a + " - " + (g.Captures.Count > 0));
    		}
    		
    		/*
    		
    		hey hello how are you ok - True
    		how are you - True
    		are you - True
    		you - False
    		how you are ok you - False
    		howareyou - False
    		howok - False
    		how you - False
    		hey hello - False
    		
    		*/
    	}
    }
