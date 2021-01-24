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
                var weather = doc.Elements("weatherdata").Select(x => new {
                    name = (string)x.Descendants("name").FirstOrDefault(),
                    country = (string)x.Descendants("country").FirstOrDefault(),
                    forecasts = x.Descendants("time").Select( y => new {
                        from = (DateTime)y.Attribute("from"),
                        to = (DateTime)y.Attribute("to"),
                        precipitation = y.Descendants("precipitation").Select(z => new {
                            unit = (string)z.Attribute("unit"),
                            value = (float)z.Attribute("value"),
                            type = (string)z.Attribute("type")
                        }).FirstOrDefault(),
                        clouds = y.Descendants("clouds").Select(z => new {
                            value = (string)z.Attribute("value"),
                            all = (int)z.Attribute("all"),
                            unit = (string)z.Attribute("unit")
                        }).FirstOrDefault()
                    }).ToList()
                }).FirstOrDefault();
            }
        }
    }
