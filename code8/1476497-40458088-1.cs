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
                var results = doc.Descendants("Category").Select(x => new {
                    name = (string)x.Element("Name"),
                    categoryDescription = (string)x.Element("CategoryDescription"),
                    symbols = x.Elements("Symbol").Select(y => new {
                        description = (string)y.Element("Description"),
                        fontFamily = (string)y.Element("FontFamily"),
                        unicodeValue = int.Parse((string)y.Element("UnicodeValue"), System.Globalization.NumberStyles.HexNumber),
                        userSymbolState = (string)y.Element("UserSymbolState")
                    }).ToList()
                }).ToList();
            }
        }
    }
