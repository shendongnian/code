    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication64
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                StringReader reader = new StringReader(xml);
                XmlSerializer xs = new XmlSerializer(typeof(GetLowestOfferListingsForASINResponse));
                GetLowestOfferListingsForASINResponse response = (GetLowestOfferListingsForASINResponse)xs.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "GetLowestOfferListingsForASINResponse", Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01")]
        public class GetLowestOfferListingsForASINResponse
        {
            [XmlElement("GetLowestOfferListingsForASINResult")]
            public List<GetLowestOfferListingsForASINResult> getLowestOfferListingsForASINResult { get; set; }
        }
        [XmlRoot(ElementName = "GetLowestOfferListingsForASINResult", Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01")]
        public class GetLowestOfferListingsForASINResult
        {
            [XmlAttribute("ASIN")]
            public string ASIN { get; set;}
            [XmlAttribute("status")]
            public string status { get; set; }
            [XmlElement("AllOfferListingsConsidered")]
            public string AllOfferListingsConsidered { get; set; }
            [XmlElement("Product")]
            public Product product { get; set; }
        }
        [XmlRoot(ElementName = "Product", Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01")]
        public class  Product
        {
            [XmlElement("Identifiers")]
            public Identifiers identifiers { get; set; }
        }
        [XmlRoot(ElementName = "Identifiers", Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01")]
        public class Identifiers
        {
        }
    }
