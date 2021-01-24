    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication23
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<string> filenames = new List<string>();
                filenames.Add(@"c:\uploadDir\20180131T083441_638_Test.doc");
                filenames.Add(@"c:\uploadDir\20180131T083441_638_Test1.doc");
                List<string> baseFilenames = filenames.Select(x => x.Substring(x.LastIndexOf("\\") + 1)).ToList();
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> filesources = doc.Descendants("filesource").ToList();
                foreach (XElement filesource in filesources)
                {
                    string uploadName = (string)filesource.Attribute("uploadName");
                    if (!baseFilenames.Contains(uploadName))
                        filesource.Remove();
                }
            }
        }
    }
