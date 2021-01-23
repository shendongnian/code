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
                string directory = "C:\\streamertest";
                addfolder(baseurl, directory, 0);
                Console.ReadLine();
            }
            public static void addfolder(string url, string directory, int level)
            {
                Console.WriteLine("{0} folder : '{1}'", new string(' ', 5 * level), url);
                //Directory.CreateDirectory(directory);
                XDocument xdoc = XDocument.Load(url);
                XElement root = (XElement)xdoc.FirstNode;
                foreach (XElement element in root.Elements())
                {
                    string type = (string)element.Attribute("type");
                    string name = (string)element.Attribute("name");
                    switch (type)
                    {
                        case "folder":
                            string newUrl = url + "/" + name;
                            string newDirectory = directory + "\\" + name;
                            addfolder(newUrl, newDirectory, level++);
                            break;
                        default:
                            string urlName = url + "/" + name;
                            Console.WriteLine("{0}   url : '{1}'", new string(' ', 5 * level), urlName);
                            break;
                    }
                }
            }
        }
    }
