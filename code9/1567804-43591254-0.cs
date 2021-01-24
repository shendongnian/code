    using System;
    using System.Text.RegularExpressions;
    public class Solution
    {
    	public static void Main(String[] args)
    	{
    		string sample = "where dog is and cats are and bird is bigger than a mouse";
    		MatchCollection matches = Regex.Matches(sample, @"(?<=(where|and)\s)(?<gr>.+?)(?=(and|$))");
    		foreach (Match m in matches)
    		{
    			Console.WriteLine(m.Value.ToString());
    		}
    	}
    }
