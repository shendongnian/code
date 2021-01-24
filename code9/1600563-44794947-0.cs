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
                List<XElement> parsedDataElements = doc.Descendants("ParsedDataElement").ToList();
                for (int i = 0; i < parsedDataElements.Count; i += 2)
                {
                    DataElement newDataElement = new DataElement();
                    DataElement.elements.Add(newDataElement);
                    newDataElement.temperature = (double)parsedDataElements[i].Element("ConvertedValue");
                    newDataElement.light = (int)parsedDataElements[i + 1].Element("ConvertedValue");
                }
            }
        }
        public class DataElement
        {
            public static List<DataElement> elements = new List<DataElement>();
            public double temperature { get; set; }
            public int light { get; set; }
        }
    }
