    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                using (StreamReader rd = new StreamReader(FILENAME))
                {
                    XDocument doc = XDocument.Load(rd);
                    XElement response = doc.Descendants().Where(x => x.Name.LocalName == "GetResponse").FirstOrDefault();
                    XNamespace ns = response.GetDefaultNamespace();
                    var data = response.Descendants(ns + "GetResult").Select(x => new {
                        distance = (int)x.Element(ns + "Distance"),
                        id = (int)x.Element(ns + "ID"),
                        name = (string)x.Element(ns + "Name"),
                        code = (string)x.Element(ns + "Code"),
                        addresss = (string)x.Element(ns + "Address1")
                    }).FirstOrDefault();
                }
            }
        }
    }
