    using System;
    using System.Collections.Generic;
    using System.Xml;
    
    namespace Folders
    {
        class Program
        {
            public static List<string> FolderNames(string xml, char startingLetter)
            {
                var list = new List<string>();
                var doc = new XmlDocument();
                doc.LoadXml(xml);
    
                FindNodes(list, doc.ChildNodes, startingLetter);
    
                return list;
            }
    
            private static void FindNodes(List<string> results, XmlNodeList nodes, char startingLetter)
            {
                foreach (XmlNode item in nodes)
                {
                    if (item.Attributes == null)
                        continue;
    
                    if (item.Attributes["name"] == null)
                        continue;
    
                    var folder = item.Attributes["name"];
                    if (folder.Value.ToLower().StartsWith(startingLetter.ToString()))
                    {
                        results.Add(folder.Value);
                    }
    
                    if (!item.HasChildNodes)
                        continue;
    
                    FindNodes(results, item.ChildNodes, startingLetter);
                }
            }
    
            public static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<folder name=\"c\">" +
                        "<folder name=\"program files\">" +
                            "<folder name=\"uninstall information\" />" +
                        "</folder>" +
                        "<folder name=\"users\" />" +
                    "</folder>";
    
                foreach (string name in FolderNames(xml, 'u'))
                    Console.WriteLine(name);
    
                Console.ReadKey();
            }
        }
    }
