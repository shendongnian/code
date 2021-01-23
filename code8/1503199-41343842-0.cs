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
                List<string> lstApprove = new List<string>() {
                    "Styles", "alto", "Description", "MeasurementUnit",
                    "sourceImageInformation",
                    "fileName", "OCRProcessing", "preProcessingStep",
                    "processingSoftware", "softwareCreator", "softwareName",
                    "softwareVersion", "ocrProcessingStep", "ParagraphStyle",
                    "Layout", "Page", "PrintSpace", "TextBlock",
                    "TextLine", "String", "SP", "ComposedBlock", "GraphicalElement"
                };
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> elements = doc.Descendants().Where(x => lstApprove.Contains(x.Name.LocalName)).ToList();
                string xml = "<?xml version=\"1.0\" encoding=\"UTF-16\"?>" +
                             "<document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"></document>";
                XDocument newDoc = XDocument.Parse(xml);
                XElement document = (XElement)newDoc.FirstNode;
                document.Add(elements);
            }
        }
    }
