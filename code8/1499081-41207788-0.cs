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
                XElement t = doc.Descendants().Where(x => x.Name.LocalName == "t").FirstOrDefault();
                t.Value = "New Value";
                doc.Save(FILENAME);
              
            }
        }
    }
