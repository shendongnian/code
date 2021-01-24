    using System;
    using System.Text.RegularExpressions;
    using System.Xml;
    using HtmlAgilityPack;
					
    public class Program
    {
		public static void Main()
		{
			var html = 
			"<div id=\"CuboPlayer1\"><div class=\"cover\" style=\"background-image: url(\"http://is5.mzstatic.com/image/thumb/Music/v4/68/b5/08/68b50896-607e-2950-3530-de172fdbf878/source/100x100bb.jpg\");\"></div></div>";
			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(html);
			string nodeHTML = htmlDoc.DocumentNode
				.SelectSingleNode("//div[@id='CuboPlayer1']").InnerHtml;
			
			string pattern = @"(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\/\\\+&amp;%\$#_]*)?";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			string backgroundURL = regex.Match(nodeHTML).Value;
			
			Console.WriteLine(backgroundURL);
		}
	}
