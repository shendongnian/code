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
                XDocument doc = XDocument.Load(FILENAME);
                int[] rsids = doc.Descendants().Where(x => x.Name.LocalName == "rsids").Select(x => new  {
                    rsids = x.Elements().Select(y => int.Parse((string)y.Attribute(x.GetNamespaceOfPrefix("w") + "val"), System.Globalization.NumberStyles.HexNumber))
                }).Select(x => x.rsids).FirstOrDefault().Select(x => x).ToArray();
            }
        }
    }
