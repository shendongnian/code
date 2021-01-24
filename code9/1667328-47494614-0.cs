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
            const string FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                RecusiveParse(root, 1, "sec");
            }
            static void RecusiveParse(XElement parent, int level, string parentId)
            {
                int index = 1;
                string prefix = "";
                if (level > 1)
                {
                    prefix = ((char)('a' + (level - 2))).ToString();
                }
                foreach (XElement child in parent.Elements("section"))
                {
                    string id = parentId + prefix + index.ToString();
                    child.Attribute("id").Value = id;
                    RecusiveParse(child, level + 1, id);
                    index++;
                }
            }
        }
    }
