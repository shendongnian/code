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
            static void Main(string[] args)
            {
                string baseurl = "http://localhost:54479/Netflix";
                addfolder(baseurl, 0);
                Console.ReadLine();
            }
            public static void addfolder(string url, int level)
            {
                Console.WriteLine("{0},folder : '{1}'", new string(' ', 5 * level), url);
                XDocument xdoc = XDocument.Load(url);
                XElement root = (XElement)xdoc.FirstNode;
                foreach (XElement element in root.Elements())
                {
                    string type = (string)element.Attribute("type");
                    switch (type)
                    {
                        case "folder":
                            string newUrl = url + "/" + (string)element.Attribute("name");
                            addfolder(newUrl, level++);
                            break;
                        default:
                            string filename = url + "/" + (string)element.Attribute("name");
                            Console.WriteLine("{0}   filename : '{1}'", new string(' ', 5 * level), filename);
                            break;
                    }
                }
            }
        }
    }
