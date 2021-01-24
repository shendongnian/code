    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication23
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<string> strings = doc.Elements().Elements().Elements().Select(x => x.Name.LocalName).ToList();
     
     
            }
        }
     
    }
