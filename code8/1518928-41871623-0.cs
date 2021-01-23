    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication43
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<int> order = new List<int>() { 1, 3, 4, 2 };
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> books = doc.Descendants("Book").OrderBy(x => order.IndexOf((int)x.Element("BookId"))).ToList();
            }
        }
     
    }
