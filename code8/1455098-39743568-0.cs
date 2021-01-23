    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication16
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> prdctNames = doc.Descendants("PrdctName").ToList();
                for (int i = prdctNames.Count - 1; i >= 0; i--)
                {
                    prdctNames[i].Remove();
                }
            }
        }
    }
  
