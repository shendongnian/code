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
                var results = doc.Descendants("ROW").Select(x => new {
                    rowID = (int)x.Element("ROWID"),
                    id = (string)x.Element("ID"),
                    type = (int)x.Element("TYPE"),
                    typeID = (int)x.Element("TYPEID"),
                    typeCode = (int)x.Element("TYPECODE"),
                    crsCode = (int)x.Element("CRSCODE"),
                }).ToList();
            }
        }
    }
