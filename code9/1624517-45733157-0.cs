    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication73
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Assignment> assignments = doc.Root.Elements().Select(x => new
                {
                    items = x.Descendants("Item").Select(y => new Assignment()
                    {
                        id = x.Name.LocalName,
                        _type = (string)y.Descendants("Type").FirstOrDefault(),
                        name = (string)y.Descendants("Name").FirstOrDefault(),
                        counsel = (string)y.Descendants("Name").FirstOrDefault().Attribute("Counsel"),
                        nextCounsil = (string)y.Descendants("Name").FirstOrDefault().Attribute("NextCounsel"),
                        completed = y.Descendants("Name").FirstOrDefault().Attribute("Completed") == null ? false :
                           ((int)y.Descendants("Name").FirstOrDefault().Attribute("Completed")) == 0 ? false : true
                    }).ToList()
                }).SelectMany(x => x.items).ToList();
            }
        }
        public struct Assignment
        {
            public string name { get; set; }
            public string id { get; set; }
            public string counsel { get; set; }
            public string nextCounsil { get; set; }
            public Boolean completed { get; set; }
            public string _type { get; set; }
        }
     
    }
