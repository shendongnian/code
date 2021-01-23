    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication33
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("struct").FirstOrDefault().Elements("member").Select(x => new {
                    name = (int)x.Element("name"),
                    imageID = x.Descendants("member").Where(y => (string)y.Element("name") == "imageID").Select(z => (int)z.Descendants("string").FirstOrDefault()).FirstOrDefault(),
                    imageURL = x.Descendants("member").Where(y => (string)y.Element("name") == "imageURL").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault(),
                }).ToList();
            }
        }
        
    }
