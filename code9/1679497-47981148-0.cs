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
                var results = doc.Descendants("release").Select(x => new {
                            id = (int)x.Element("id"),
                            name = (string)x.Element("name"),
                            publisher = (string)x.Element("publisher"),
                            region = (string)x.Element("region"),
                            languages = (string)x.Element("languages"),
                            group = (string)x.Element("group"),
                            imagesize = (int)x.Element("imagesize"),
                            serial = (string)x.Element("serial"),
                            titleid = (string)x.Element("titleid"),
                            imgcrc = (string)x.Element("imgcrc"),
                            filename = (string)x.Element("filename"),
                            releasename= (string)x.Element("releasename"),
                            trimmedsize = (int)x.Element("trimmedsize"),
                            firmware = (string)x.Element("firmware"),
                            type = (int)x.Element("type"),
                            card = (int)x.Element("card")
                }).ToList();
            }
        }
    }
