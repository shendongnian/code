    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication34
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement alt = doc.Descendants("alternateID").Where(x => (string)x.Attribute("code") == "ALT").FirstOrDefault();
                alt.Value = "00000000";
     
            }
        }
    }
