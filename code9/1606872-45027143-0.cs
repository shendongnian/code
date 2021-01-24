    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Result));
                StringReader rdr = new StringReader(xml);
                Result resultingMessage = (Result)serializer.Deserialize(rdr);
            }
        }
        public enum ReportType
        {
            [XmlEnum("0")]
            InternalErrorReport,
            [XmlEnum("1")]
            ErrorReport,
            [XmlEnum("2")]
            InternalSuccessReport
        }
        [XmlRoot(ElementName = "result")]
        public class Result
        {
            [XmlElement(ElementName = "reporttype")]
            public ReportType reportType { get; set; }
            public Items items { get; set; }
            public string error { get; set; }
     
        }
        [XmlRoot("items")]
        public class Items
        {
            [XmlElement(ElementName = "item")]
            public List<Item> items = new List<Item>();
        }
        [XmlRoot("item")]
        public class Item
        {
            [XmlElement(ElementName = "sku")]
            public string sku { get; set; }
            [XmlElement(ElementName = "style")]
            public string style { get; set; }
            [XmlElement(ElementName = "reason")]
            public string reason { get; set; }
        }
    }
