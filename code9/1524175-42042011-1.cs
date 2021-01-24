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
                XDocument sdmx_response = XDocument.Load(FILENAME);
                XNamespace message = sdmx_response.Root.GetDefaultNamespace();
                XNamespace generic = sdmx_response.Root.GetDefaultNamespace();
                IEnumerable<XElement> DataSet = sdmx_response.Root.Elements(message + "DataSet");
                IEnumerable<XElement> Series = DataSet.Elements(generic + "Series").Select(series => new XElement("Series", new object[] {
                    new XElement("SeriesKey", 
                        series.Elements(generic + "SeriesKey").Elements("Value").Where(value =>((string)value.Attribute("id") == "PRODUCT" && (string)value.Attribute("value") == "Lumber") || ((string)value.Attribute("id") == "FIN" && (string)value.Attribute("export") == "Lumber"))
                        ),
                    series.Elements(generic + "Obs")
                })).ToList();
     
            }
        }
     
    }
