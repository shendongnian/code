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
            const string BASE_URL = "http://localhost:54479";
            static void Main(string[] args)
            {
                string url = "/data/data.xml?id=netflix";
                string directory = "C:\\streamertest";
                string path = "Netflix";
                addfolder(path, url, directory, 0);
                Console.ReadLine();
            }
            public static void addfolder(string path, string url, string directory, int level)
            {
                Console.WriteLine("{0} folder : '{1}'", new string('.', 5 * level), path);
                //Directory.CreateDirectory(directory);
                XDocument xdoc = XDocument.Load(BASE_URL + url);
                XElement root = (XElement)xdoc.FirstNode;
                foreach (XElement element in root.Elements())
                {
                    string type = (string)element.Attribute("type");
                    string name = (string)element.Attribute("name");
                    string href = (string)element.Attribute("href");
                    switch (type)
                    {
                        case "folder":
                            string newpath = path + "/" + name;
                            string newDirectory = directory + "\\" + name;
                            addfolder(newpath, href, newDirectory, level++);
                            break;
                        default:
                            string pathName = path + "/" + name;
                            Console.WriteLine("{0}   url : '{1}'", new string(' ', 5 * level), pathName);
                            break;
                    }
                }
            }
        }
    }
