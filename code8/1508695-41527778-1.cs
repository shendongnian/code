    using System.Xml;
    using System.IO;
    
    namespace ReutersXML
    {
        class Program
        {
            static void Main()
            {
                XmlDocument xmlDoc = new XmlDocument();
                
                xmlDoc.Load("reuters.xml");
    
                var reuters = xmlDoc.GetElementsByTagName("REUTERS");
                var article = reuters[0].Attributes.GetNamedItem("NEWID").Value;
                var subject = xmlDoc.GetElementsByTagName("TITLE")[0].InnerText;
                var body = xmlDoc.GetElementsByTagName("BODY")[0].InnerText;
    
                string[] sentences = body.Split(new string[] { System.Environment.NewLine },
                    System.StringSplitOptions.RemoveEmptyEntries);
    
                using (FileStream fileStream = new FileStream("reuters_new.xml", FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fileStream))
                using (XmlTextWriter xmlWriter = new XmlTextWriter(sw))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.Indentation = 4;
    
                    xmlWriter.WriteStartElement("articles");
                    xmlWriter.WriteStartElement("article");
                    xmlWriter.WriteAttributeString("id", article);
                    xmlWriter.WriteElementString("subject", subject);
    
                    foreach (var s in sentences)
                        if (s.Length > 10)
                            xmlWriter.WriteElementString("sentence", s);
    
                    xmlWriter.WriteEndElement();
                }
            }
        }
    }
