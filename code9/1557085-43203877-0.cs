    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("Item").Select(x => new {
                    name = (string)x.Element("Name"),
                    count = (int)x.Element("Count"),
                    price = (decimal)x.Element("Price"),
                    comment = (string)x.Element("Comment"),
                    artist = (string)x.Element("Artist"),
                    publisher = (string)x.Element("Publisher"),
                    genre = (string)x.Element("Genre"),
                    year = (int)x.Element("Year"),
                    productID = (string)x.Element("ProductID")
                }).ToList();
            }
        }
     
       
    }
