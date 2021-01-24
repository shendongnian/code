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
                DeactivationsGroup.GroupNames = doc.Descendants("Group").Select(x => new {
                    languages = x.Elements().Where(y => y.Element("GroupName") != null).Select(y => new DeactivationsGroup() { 
                       name = (string)y.Element("GroupName"),
                       level = (int)x.Element("Level"),
                       index = byte.Parse((string)x.Attribute("index")),
                       language = y.Name.LocalName
                    })
                }).SelectMany(y => y.languages)
                .GroupBy(x => x.name, y => y)
                .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
            public class DeactivationsGroup
            {
                public static Dictionary<string, DeactivationsGroup> GroupNames { get; set; }
                public string name { get; set; }
                public int level { get; set; }
                public byte index { get; set; }
                public string language { get; set; }
            }
        }
    }
