    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace ConsoleApp12
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var doc = XDocument.Load(@"c:\temp\foo.xml");
                var ns = (XNamespace)"http://schemas.microsoft.com/exchange/services/2006/types";
    
                var folders = doc.Descendants(ns + "Folder");
    
                foreach (var e in folders)
                {
                    var folderId = e.Element(ns + "FolderId").Attribute("Id").Value;
                    Console.WriteLine(folderId);
                }
    
                Console.WriteLine("Hit any key to exit.");
                Console.ReadKey();
    
            }
        }
    }
