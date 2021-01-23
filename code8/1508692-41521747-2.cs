    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
    	public static void Main()
    	{
    		var input = @"Standard Oil Co and BP North America
    Inc said they plan to form a venture to manage the money market
    borrowing and investment activities of both companies.
    BP North America is a subsidiary of British Petroleum Co
    Plc <BP>, which also owns a 55 pct interest in Standard Oil.
    The venture will be called BP/Standard Financial Trading
    and will be operated by Standard Oil under the oversight of a
    joint management committee.";
    		var pattern = @"(?<=[\.!\?])\s+";
    		var sentences = Regex.Split(input, pattern);
    		foreach (var sentence in sentences)
    		{
    			var innerText = sentence.Replace("\n", " ").Replace('\t', ' ');
    			//do something with the sentence
    			var node = string.Format("\t \t <sentence>{0}</sentence>", innerText);
    			Console.WriteLine(node);
    		}
    	}
    }
