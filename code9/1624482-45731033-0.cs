    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    namespace Test {
        class Program {
            public static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("PATHTOXMLFILE");
                List<string> result = RetrieveValues(doc, "Include");
                foreach(string item in result)
                {
                    Console.WriteLine(item);
                }
                Console.Read();
            }
    
            public static List<string> RetrieveValues(XmlDocument doc, string attributeName)
            {
                var list = new List<string>();
    
                string xpath = @"//*[@" + attributeName + "]";
                XmlNodeList xmlNodeList = doc.SelectNodes(xpath);
    
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    list.Add(xmlNode.Attributes[attributeName].InnerText);
                }
    
                return list;
            }
        }
    }
