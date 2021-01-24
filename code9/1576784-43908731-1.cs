    using System;
	using System.Text.RegularExpressions;
						
	public class Program
	{
		public static void Main()
		{
			string data = "<h2 class=\"product-name\"><a href=\"erkek-ayakkabi-spor-gri-17sfd3007141340-p\" title=\"...\">...</a></h2>\r\n<h2 class=\"test-name\"><a href=\"erkek-ayakkabi-spor-gri-17sfd3007141340-p\" title=\"...\">...</a></h2>\r\n<h2 class=\"product-name\"><a href=\"erkek-ayakkabi-spor-gri-17sfd3007141340-p\" title=\"...\">...</a></h2>\r\n";
			//string regex = "class=\"product-name\"(.*)<a\\shref=\"(.*?)\"";
            string regex = "class=\"product-name\".*<a\\shref=\"(.*?)\"";
			var matches = Regex.Matches(data, regex, RegexOptions.Multiline);
			foreach(Match item in matches)
			{
				//Console.WriteLine("Value: " + item.Groups[2]);
                Console.WriteLine("Value: " + item.Groups[1]);
			}
		}
	}
