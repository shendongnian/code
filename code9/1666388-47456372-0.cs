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
                XmlReader reader = XmlReader.Create(FILENAME);
                reader.ReadToFollowing("Modules4");
                XmlReader module4Subtree = reader.ReadSubtree();
                while (!module4Subtree.EOF)
                {
                    if (module4Subtree.Name != "Module")
                    {
                        module4Subtree.ReadToFollowing("Module");
                    }
                    if (!module4Subtree.EOF)
                    {
                        XElement module = (XElement)XElement.ReadFrom(module4Subtree);
                        Module.modules.Add(new Module() { name = (string)module.Element("Name"), code = (string)module.Element("Code"), credits = (int)module.Element("Credits") });
                    }
                }
            }
        }
        public class Module
        {
            public static List<Module> modules = new List<Module>();
            public string name { get; set; }
            public string code { get; set; }
            public int credits { get; set; }
        }
    }
