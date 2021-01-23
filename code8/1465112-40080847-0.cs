    sing System;
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
                List<XElement> nulls = doc.Descendants().Where(x => (string)x == "null").ToList();
                for (int i = nulls.Count - 1; i >= 0; i--)
                {
                    nulls[i].Remove();
                }
            }
        }
    }
