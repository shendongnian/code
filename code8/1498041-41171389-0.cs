    using System;
    using System.Web;
    using System.Xml;
    using System.Xml.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		//The XML declaration is not required, however, if used it must 
    		// be the first line in the document and no other content or 
    		//white space can precede it.
    		
    		// here, no problem because this does not have an XML declaration
    		    string xml = @"                                                               
                             <xml></xml>";
                XDocument doc = XDocument.Parse(xml);
                Console.WriteLine(doc.Document.Declaration);
                Console.WriteLine(doc.Document);
    		//
    		// problem here because this does have an XML declaration
    		//
    		xml = @"                                      
    		<?xml version=""1.0"" encoding=""utf-8"" ?><xml></xml>";
    		try 
    		{
    		doc = XDocument.Parse(xml);
                Console.WriteLine(doc.Document.Declaration);
                Console.WriteLine(doc.Document);
    		} catch(Exception e) {
    			Console.WriteLine(e.Message);
    		}
    
    	}
    }
