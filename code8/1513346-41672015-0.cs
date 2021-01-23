    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string text = @"It is @google.com or @google w@google \@google \\@google";
      		string result = SafeReplace(text,"@google", "some domain", true);
    		Console.WriteLine(result);
    	}
    	
    	
    	public static string SafeReplace(string input, string find, string replace, bool matchWholeWord)
        {
            string textToFind = matchWholeWord ? string.Format(@"(?<!\w)(?<!\\)((?:\\\\)*){0}(?!\w)", Regex.Escape(find)) : find;
            return Regex.Replace(input, textToFind, string.Format("$1{0}",replace.Replace("$","$$")));
        }
    }
