    using System;
    using Newtonsoft.Json;
    using System.Xml.Linq;
    using System.Xml;
    
    public class Program
    {
    	public static void Main()
    	{
    		string json = @"{
    						  'status': 'true',
    						  'Code': '200',
    						  'data': [
    							{
    							  'name': 'ram',
    							  'age': '21'
    							}
    						  ]
    						}";
    		XNode node = JsonConvert.DeserializeXNode(json, "Root");
    		Console.WriteLine(node.ToString());
    	}
    }
