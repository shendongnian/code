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
                XDocument xdoc = XDocument.Load(FILENAME);
                XElement parent = (XElement)xdoc.FirstNode;
                string folderName = (string)parent.Attribute("name");
                Console.WriteLine("folder : '{0}'", folderName);
                addfolder(parent, @"c:\", 0);
                Console.ReadLine();
            }
            public static void addfolder(XElement parent, string path, int level)
            {
                // xdoc.Save(Console.Out);
                foreach (XElement element in parent.Elements())
                {
                    string type = (string)element.Attribute("type");
                    switch(type)
                    {
                        case "folder" :
                            string folderName = (string)element.Attribute("name");
                            Console.WriteLine("{0},folder : '{1}'", new string(' ', 5 * level), folderName);
                            string newPath = path + "\\" + folderName.Replace(":", "-");
                            addfolder(element, newPath, level++);
                            
                            break;
                        default :
                            string filename = path + "\\" + ((string)element.Attribute("name")).Replace(":", "-") + "_data.xml";
                            Console.WriteLine("{0}   filename : '{1}'", new string(' ', 5 * level), filename);
                            break;
                    }
                }
            }
        }
    }
