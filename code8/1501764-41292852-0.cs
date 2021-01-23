    using System;
    using System.Xml;
    
    namespace ConsoleApplication1 {
    	class Program {
    		static void Main(string[] args) {
    			XmlDocument xml = new XmlDocument();
    			xml.Load("c:\\temp\\test.xml");
    
    			NameTable nt = new NameTable();
    			XmlNamespaceManager nsmgr;
    			nsmgr = new XmlNamespaceManager(nt);
    			nsmgr.AddNamespace("html", xml.DocumentElement.NamespaceURI);
    
    			XmlNode ndFormat = xml.SelectSingleNode("//html:formatting[@lang='']", nsmgr);
    			if (ndFormat != null) {
    				Console.WriteLine(ndFormat.InnerText);
    			}
    
    		}
    	}
    }
