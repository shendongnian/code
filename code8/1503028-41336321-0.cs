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
                DataSet ds = doc.Descendants("DataSet").Select(x => new DataSet() {
                    nameField = (string)x.Element("Name"),
                    scaleField = (string)x.Element("Scale"),
                    barIntervalField = (string)x.Element("BarInterval"),
                    dSStringField = (string)x.Element("DSString"),
                    providerNameField = (string)x.Element("ProviderName")
                }).FirstOrDefault();
            }
        }
        public partial class DataSet
        {
            public string nameField { get; set; }
            public string scaleField { get; set; }
            public string barIntervalField { get; set; }
            public string dSStringField { get; set; }
            public string providerNameField { get; set; }
        }
    }
