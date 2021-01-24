    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace XmlParser
    {
    	public class Test {
    		public static void Main(string []args) {
    			XDocument document = XDocument.Load("test.svg");
    			XNamespace ns = "http://www.w3.org/2000/svg";
    
    			var list = document.Root.Descendants(ns + "rect").Select(e => new {
    				Width = e.Attribute("width").Value,
    				Height = e.Attribute("height").Value,
    				X = e.Attribute("x").Value
    			});
    
    			foreach (var item in list) {
    				Console.WriteLine("Width: {0}, Height: {1}, X: {2}", item.Width, item.Height, item.X);
    			}
    
    			// Output:
    			// Width: 45.714287, Height: 30, X: 37.387959
    			// Width: 45.714287, Height: 30, X: 91.899246
    		}
    	}
    }
