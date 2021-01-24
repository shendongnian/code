    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                IEnumerable<XElement> NormalizedDataSet = NormalizeGeneric(FILENAME);
                foreach (XElement Series in NormalizedDataSet)
                {
                    Console.WriteLine(Series);
                }
            }
            public IEnumerable<XElement> NormalizeGeneric(string XmlString)
            {
                XDocument xml_response = XDocument.Parse(XmlString);
                XNamespace message = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message";
                XNamespace generic = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic";
                XElement SeriesSet = xml_response.Root;
                IEnumerable<XElement> SeriesObject = seriesSet.Elements(message + "DataSet")
                                                              .Elements(generic + "Series")
                                                              .Select(series => new XElement("Series", new object[]
                {
                    new XElement("Metadata", 
                                series.Elements(generic + "SeriesKey")
                                      .Elements(generic + "Value")
                                      .Select(value => new XElement((string)value.Attribute("id"), new XAttribute("value", (string)value.Attribute("value"))))),
                    new XElement("Data", 
                                series.Elements(generic + "Obs")
                                      .Select(observations => new XElement("Observation", new XAttribute((string)observations.Element(generic + "ObsDimension")
                                                                                                                             .Attribute("id"), (string)observations.Element(generic + "ObsDimension").Attribute("value")), new XAttribute("value", (string)observations.Element(generic + "ObsValue").Attribute("value")), new XElement("Attributes", observations.Elements(generic + "Attributes").Elements(generic + "Value").Select(attributes => new XElement((string)attributes.Attribute("id"), new XAttribute("value", (string)attributes.Attribute("value"))))))))
                })).ToArray();
                return SeriesObject;
            }
        }
    }
