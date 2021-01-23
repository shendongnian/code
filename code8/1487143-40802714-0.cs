    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> dialogueHistory = doc.Descendants().Where(x => x.Name.LocalName == "dialogueHistory").ToList();
                XNamespace ns = dialogueHistory.FirstOrDefault().GetDefaultNamespace();
                var results = dialogueHistory.Select(x => new {
                    id = (string)x.Attribute("id"),
                    messageId = (int)x.Element(ns + "MessageID"),
                    messageText = (string)x.Element(ns + "messageText"),
                    messageDate = (DateTime)x.Element(ns + "msgDate"),
                    unReadCount = (int)x.Element(ns + "unReadCount")
                }).ToList();
            }
        }
    }
