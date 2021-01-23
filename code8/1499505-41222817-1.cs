	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Xml.Linq;
	public class Program
	{	
	    public static void Main()
	    {
	        string response = @"Hello World <Red>This is some red text </Red> This is normal <Blue>This is blue text </Blue>";
			response = @"<?xml version='1.0' encoding='utf-8'?><root>"+response+"</root>";
	        var doc = XDocument.Parse(response);
			
			// fill all node in a list of Text
			var colors = new List<Text>();
			foreach (var hashElement in doc.Descendants().Skip(1).Where(node => !node.IsEmpty))
	        {
				var text = GetText(hashElement.PreviousNode);
				if (text != null)
					colors.Add(new Text(text));
				colors.Add(new Text(hashElement.Value.Trim(), hashElement.Name.ToString()));
	        }
			
			// handle trailing content
			var lastText = GetText(doc.Descendants().Last().NextNode);
			if (lastText != null)
				colors.Add(new Text(lastText));
			
			// print
			foreach (var color in colors)
				Console.WriteLine($"{color.Color}: {color.Content}");
    	}
	
		private static string GetText(XNode node)=> (node as XText)?.Value.Trim();
		public class Text
		{
			public string Content { get; set; }
			public string Color { get; set; }
	
			public Text(string content, string color = "Black")
			{
				Color = color;
				Content = content;
			}
		}
	}
