    using System;
	using System.Xml;
	using System.Linq;
	using System.Xml.Linq;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			//var xDoc = XDocument.Load(filename);
			var XDoc = XDocument.Parse(@"<root><a><b><c>value</c></b></a><b><c>no</c></b><a><c>no</c></a></root>");
			Console.WriteLine("Params a b c ");
			foreach(var nodeValue in XDoc.Root.GetValueForNodeIfExists("a", "b", "c"))
			{
				Console.WriteLine(nodeValue);
			}
			
			Console.WriteLine("List a b c ");
			foreach(var nodeValue in XDoc.Root.GetValueForNodeIfExists("a", "b", "c"))
			{
				Console.WriteLine(nodeValue);
			}
		}
	}	
	
	
	internal static class XElementExtensions
	{
		public static IEnumerable<string> GetValueForNodeIfExists(this XElement node, params string[] childNodesNames)
		{
			return GetValueForNodeIfExists(node, childNodesNames.ToList());
		}
	
		public static IEnumerable<string> GetValueForNodeIfExists(this XElement node, IEnumerable<string> childNodesNames)
		{
			IEnumerable<XElement> nodes = new List<XElement> { node };
			
			foreach(var name in childNodesNames)
			{
				nodes = FilterChildrenByName(nodes, name);
			}
			
			var result = nodes.Select(n => n.Value);
			
			return result;
		}
		
		private static IEnumerable<XElement> FilterChildrenByName(IEnumerable<XElement> nodes, string filterName)
		{
			var result = nodes
				.SelectMany(n => n.Elements(filterName));
			
			Console.WriteLine("Filtering by {0}, found {1} elements", filterName, result.Count());
			
			return result;			
		}
	}
