	using System;
	using System.Xml;
					
	public class Program
	{
		
		public static void WalkXml(XmlElement node, ref int index) {
		
			node.SetAttribute("startIndex", index.ToString());
		
			foreach(XmlNode child in node.ChildNodes) {
				XmlElement element = (child as XmlElement);
				if (element != null) {
					index++;
					WalkXml(element, ref index);
				}
			
			}
			node.SetAttribute("endIndex", (++index).ToString());
		}
	
		public static void WriteXml(string message, string[] tags) {
			var xmlStr = $"<seg>{String.Format(message, tags)}</seg>";
			var xmlObj = new XmlDocument();
			xmlObj.LoadXml(xmlStr);
		
			int index = 1;
			WalkXml(xmlObj.DocumentElement, ref index);		
		
			Console.WriteLine(xmlObj.InnerXml);
		}
	
		public static void Main()
		{
			string[] tags1 = new string[] {
				"<cf underline=\"single\">",
				"<cf bold=\"True\">",
				"</cf>",
				"</cf>"
			};
		
			string[] tags2 = new string[] {
				"<cf underline=\"single\">",
				"</cf>",
				"<cf bold=\"True\">",
				"</cf>"
			};		
		
			string message = "This {0} is {1}really{2} great {3}, isn't it?";
		
			WriteXml(message, tags1);
			WriteXml(message, tags2);
		}
	}
