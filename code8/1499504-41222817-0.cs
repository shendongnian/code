	using System;
	using System.Linq;
	using System.Xml.Linq;
	
	public class Program
	{
	    public static void Main()
	    {
	        string response = @"Hello World <Red>This is some red text </Red> This is normal <Blue>This is blue text </Blue>";
	
			response = @"<?xml version='1.0' encoding='utf-8'?><root>"+response+"</root>";
	        var doc = XDocument.Parse(response);
	        foreach (var hashElement in doc.Descendants().Skip(1).Where(node => !node.IsEmpty))
	        {
	            Console.WriteLine(GetText(hashElement.PreviousNode));
	            Console.WriteLine(hashElement.Value.Trim());
	        }
			Console.WriteLine(GetText(doc.Descendants().Last().NextNode));
    	}
	
		private static string GetText(XNode node)=> (node as XText)?.Value.Trim();
	}
