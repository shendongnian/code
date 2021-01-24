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
                var groups = doc.Descendants("PackageDetail")
                    .GroupBy(x => new {
                        Weight = (string)x.Element("Weight"),
                        PackageDimensionsLength = (string)x.Element("PackageDimensionsLength"),
                        PackageDimensionsWidth = (string)x.Element("PackageDimensionsWidth"),
                        PackageDimensionsHeight = (string)x.Element("PackageDimensionsHeight")
                    }).ToList();
                foreach (var group in groups)
                {
                    foreach (XElement packageDetail in group.Skip(1))
                    {
                        packageDetail.Remove();
                    }
                }
            }
        }
    }
