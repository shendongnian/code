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
                List<XElement> attributes = doc.Descendants().Where(x => x.Name.LocalName == "attributes").ToList();
                XNamespace esNs = attributes.FirstOrDefault().GetNamespaceOfPrefix("es");
                List<CellName> cells = attributes.Select(x => new CellName() {
                    cellId = (int)x.Element(esNs + "cellId"),
                    crsGain = (int)x.Element(esNs + "crsGain")
                }).ToList();
            }
        }
        public class CellName
        {
            public int cellId { get; set; }
            public int crsGain { get; set; }
        }
    }
