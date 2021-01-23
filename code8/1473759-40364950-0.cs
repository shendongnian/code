    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication22
    {
        class Program
        {
            const string FILENAME = @"c:\TEMP\TEST.XML";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("product").Select(x => new {
                    name = (string)x.Element("name"),
                    slot = x.Elements("slot").Select(y => new {
                        agent_id = (int)y.Element("agent_id"),
                        agent_name = (string)y.Element("agent_name"),
                        index_id = (int)y.Element("index_id"),
                        slot_alias = (string)y.Element("slot_alias")
                    }).FirstOrDefault()
                }).ToList();
            }
        }
     
    }
