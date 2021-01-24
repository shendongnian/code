    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication5
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> codes = doc.Descendants().Where(x => x.Attribute("code") != null).ToList();
                foreach (XElement code in codes)
                {
                    code.ReplaceWith(new XElement(code.Name.LocalName, (string)code.Attribute("code")));
                }
            }
        }
    }
