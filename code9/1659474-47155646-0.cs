    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication13
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> ids = doc.Descendants().Where(x => x.Attribute("ID") != null).ToList();
                int indNo = 1;
                foreach (XElement id in ids)
                {
                    id.Attribute("ID").SetValue(indNo++);
                }
     
            }
            
        }
     
    }
