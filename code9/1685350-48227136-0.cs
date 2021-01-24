    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication19
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new Level(FILENAME);
            }
        }
        public class Level
        {
            public static Level root = new Level();
            public string name { get; set; }
            public int? id { get; set; }
            public string text { get; set; }
            public List<Level> children { get; set; }
            public Level() { }
            public Level(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement xRoot = doc.Root;
                ParseTree(xRoot, root);
            }
            public void ParseTree(XElement xParent, Level parent)
            {
                parent.id = (int?)xParent.Element("id");
                parent.text = xParent.NextNode  != null ? xParent.Value : "";
                foreach(XElement level in xParent.Elements().Where(x => x.Name.LocalName.StartsWith("level")))
                {
                    Level child = new Level();
                    if(parent.children == null) parent.children = new List<Level>();
                    parent.children.Add(child);
                    ParseTree(level, child);
                }
            }
        }
    }
