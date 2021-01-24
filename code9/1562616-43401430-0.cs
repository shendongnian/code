    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
        public static void Main()
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<?xml version='1.0' encoding='UTF-8' standalone='no'?><root><lastBuildDate>Thu, 13 Apr 2017</lastBuildDate></root>");
    
                XmlNodeList list = doc.GetElementsByTagName("lastBuildDate");
                foreach(XmlNode node in list )
                {
                    DateTime result = new DateTime();
                    if (DateTime.TryParse(node.InnerXml, out result))
                    {
                        node.InnerText = result.ToString("ddd, d MMM yyyy HH:mm:ss") + "+0000"; //Thu, 13 Apr 2017 09:00:52 +0000
                    }
                }
                using (var stringWriter = new StringWriter())
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    doc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    Console.Write(stringWriter.GetStringBuilder().ToString());
                }
            }
        }
    }
