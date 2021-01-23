    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                //skip xml identification with UTF-16
                reader.ReadLine();
                XDocument doc = XDocument.Load(reader);
                XElement body = doc.Descendants().Where(x => x.Name.LocalName == "body").FirstOrDefault();
                XNamespace ns = body.GetDefaultNamespace();
                var results = new {
                    sections = body.Elements(ns + "section").Select(x => new {
                        l = (int)x.Attribute("l"),
                        r = (int)x.Attribute("r"),
                        b = (int)x.Attribute("b"),
                        runs = x.Descendants(ns + "run").Select(y => new {
                            wds = y.Elements(ns + "wd").Select(z => new {
                                chs = z.Elements(ns + "ch").Select(a => new {
                                    l = (int?)a.Attribute("l"),
                                    t = (int?)a.Attribute("t"),
                                    r = (int?)a.Attribute("r"),
                                    b = (int?)a.Attribute("b"),
                                    conf = (int?)a.Attribute("conf"),
                                    value = (string)a
                                }).ToList()
                            }).ToList()
                        }).ToList()
                    }).ToList(),
                    dds = body.Elements(ns + "dd").ToList()
                };
            }
        }
    }
