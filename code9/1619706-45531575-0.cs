    using System.IO;
    using System.Xml.Linq;
    
    namespace XmlAddElementWithoutLoading
    {
        class Program
        {
            static void Main()
            {
                var rootelement = "root";
                var doc = GetDocumentWithNewNodes(rootelement);
                var newNodes = GetXmlOfNewNodes(doc);
    
                using (var fs = new FileStream("pathToDoc.xml", FileMode.Open, FileAccess.ReadWrite))
                {
                    using (var writer = new StreamWriter(fs))
                    {
                        RemoveClosingRootNode(fs, rootelement);
                        writer.Write(newNodes);
                        writer.Write("</"+rootelement+">");
                    }
                }
            }
    
            private static void RemoveClosingRootNode(FileStream fs, string rootelement)
            {
                fs.SetLength(fs.Length - ("</" + rootelement + ">").Length);
                fs.Seek(0, SeekOrigin.End);
            }
    
            private static string GetXmlOfNewNodes(XDocument doc)
            {
                var reader = doc.Root.CreateReader();
                reader.MoveToContent();
                return reader.ReadInnerXml();
            }
    
            private static XDocument GetDocumentWithNewNodes(string rootelement)
            {
                var doc = XDocument.Parse("<" + rootelement + "/>");
                var childId = "2";
                XNamespace ns = "namespace";
                doc.Root.Add(new XElement(ns + "anotherChild", new XAttribute("child-id", childId)));
                return doc;
            }
        }
    }
