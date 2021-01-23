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
                addfolder(FILENAME, "C:\\streamertest\\");
            }
            public static void addfolder(string url, string parentFolder)
            {
                string baseurl = null;
                string path = string.Empty;
                XDocument xdoc = XDocument.Load(FILENAME);
                // xdoc.Save(Console.Out);
                foreach (XElement groups in xdoc.Descendants().Where(x => (string)x.Attribute("type") =="folder"))
                {
                    string folderName = (string)groups.Attribute("name");
                    Console.WriteLine("folder : '{0}'", folderName);
                    path = path + "\\" + folderName.Replace(":", "-");
                    //Directory.CreateDirectory("C:\\streamertest\\" + path.Replace(":", "-"));
                    foreach (XElement group in groups.Elements("group"))
                    {
                        string filename = ((string)group.Attribute("name")).Replace(":", "-") + "_data.xml";
                        Console.WriteLine("   filename : '{0}'",filename);
                    }
               }
                Console.ReadLine();
            }
        }
     
    }
