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
                List<XElement> mobiles = doc.Descendants("Mobile").ToList();
                mobiles = mobiles.Where(x => (string)x.Element("FullName") != "Galaxy S-4").ToList();
                mobiles = mobiles.Where(x => (string)x.Attribute("RegDate") != "26/05/2017").ToList();
                doc.Descendants("Mobiles").FirstOrDefault().ReplaceWith(new XElement("Mobiles", mobiles));
            }
        }
    }
