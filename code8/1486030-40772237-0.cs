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
                string searchName = "The Autobiography of Benjamin Franklin";
                XElement book = doc.Descendants("book").Where(x => (string)x.Element("title") == searchName).FirstOrDefault();
                XElement price = book.Element("price");
                price.SetValue("10.00");
            }
        }
    }
