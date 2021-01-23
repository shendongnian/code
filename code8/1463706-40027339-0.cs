(#[^#]+#)
	using System;
	using System.Text.RegularExpressions;
	public class Example
	{
	   public static void Main()
	   {
	      string pattern = @"(#[^#]+#)";
	      Regex rgx = new Regex(pattern);
	      string sentence = "#blah blah# asdfasdfaf #somethingelse#";
	      foreach (Match match in rgx.Matches(sentence))
		 Console.WriteLine("Found '{0}' at position {1}", 
				   match.Value, match.Index);
	   }
	}
