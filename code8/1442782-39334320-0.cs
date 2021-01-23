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
            const string FILENAME1 = @"c:\temp\test.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc1 = XDocument.Load(FILENAME1);
                XElement root1 = (XElement)doc1.FirstNode;
                XDocument doc2 = XDocument.Load(FILENAME2);
                XElement root2 = (XElement)doc2.FirstNode;
                root1.Add(root2.Elements());
            }
        }
    }
