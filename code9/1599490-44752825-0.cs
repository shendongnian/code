    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Test test = new Test(FILENAME);
            }
        }
        public class Test
        {
            public Test(string filename)
            {
                DeserializeStanData(File.ReadAllText(filename));
            }
            private BCAmessage DeserializeStanData(string stanresponse)
            {
                BCAmessage dsResult = null;
                string xmlStanResponseText = stanresponse;
                XmlSerializer serializerStan = new XmlSerializer(typeof(BCAmessage));
                using (TextReader xmlResponseText = new StringReader(xmlStanResponseText))
                {
                    dsResult = (BCAmessage)serializerStan.Deserialize(xmlResponseText);
                }
                return dsResult;
            }
        }
        [XmlRoot(ElementName = "asic-report")]
        public class Asicreport
        {
            [XmlElement(ElementName = "asic-name")]
            public string Asicname { get; set; }
            [XmlElement(ElementName = "asic-organisation-number")]
            public string Asicorganisationnumber { get; set; }
            [XmlElement(ElementName = "asic-a-b-n")]
            public string Asicabn { get; set; }
            [XmlElement(ElementName = "asic-organisation-number-heading")]
            public string Asicorganisationnumberheading { get; set; }
            [XmlElement(ElementName = "asic-type")]
            public string Asictype { get; set; }
            [XmlElement(ElementName = "asic-status")]
            public string Asicstatus { get; set; }
            [XmlElement(ElementName = "asic-jurisdiction")]
            public string Asicjurisdiction { get; set; }
            [XmlElement(ElementName = "asic-locality")]
            public string Asiclocality { get; set; }
            [XmlElement(ElementName = "asic-address-state")]
            public string Asicaddressstate { get; set; }
            [XmlElement(ElementName = "asic-postcode")]
            public string Asicpostcode { get; set; }
        }
        [XmlRoot(ElementName = "australian-business-register-report")]
        public class Australianbusinessregisterreport
        {
            [XmlElement(ElementName = "ASICNumber")]
            public string ASICNumber { get; set; }
            [XmlElement(ElementName = "ABN")]
            public string ABN { get; set; }
            [XmlElement(ElementName = "ABNStatus")]
            public string ABNStatus { get; set; }
            [XmlElement(ElementName = "ABNStatusFromDate")]
            public string ABNStatusFromDate { get; set; }
            [XmlElement(ElementName = "EntityTypeInd")]
            public string EntityTypeInd { get; set; }
            [XmlElement(ElementName = "Non-IndividualName")]
            public string NonIndividualName { get; set; }
            [XmlElement(ElementName = "BusinessAddressState")]
            public string BusinessAddressState { get; set; }
            [XmlElement(ElementName = "BusinessAddressPostcode")]
            public string BusinessAddressPostcode { get; set; }
            [XmlElement(ElementName = "GSTStatus")]
            public string GSTStatus { get; set; }
            [XmlElement(ElementName = "GSTStatusFromDate")]
            public string GSTStatusFromDate { get; set; }
            [XmlElement(ElementName = "TradingName")]
            public string TradingName { get; set; }
        }
        [XmlRoot(ElementName = "street-type")]
        public class Streettype
        {
            [XmlAttribute(AttributeName = "code")]
            public string Code { get; set; }
        }
        [XmlRoot(ElementName = "address")]
        public class Address
        {
            [XmlElement(ElementName = "unit-number")]
            public string Unitnumber { get; set; }
            [XmlElement(ElementName = "street-number")]
            public string Streetnumber { get; set; }
            [XmlElement(ElementName = "property")]
            public string Property { get; set; }
            [XmlElement(ElementName = "street-name")]
            public string Streetname { get; set; }
            [XmlElement(ElementName = "street-type")]
            public Streettype Streettype { get; set; }
            [XmlElement(ElementName = "suburb")]
            public string Suburb { get; set; }
            [XmlElement(ElementName = "state")]
            public string State { get; set; }
            [XmlElement(ElementName = "postcode")]
            public string Postcode { get; set; }
            [XmlAttribute(AttributeName = "first-reported")]
            public string Firstreported { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
        }
        [XmlRoot(ElementName = "bureau-report")]
        public class Bureaureport
        {
            [XmlElement(ElementName = "address")]
            public Address Address { get; set; }
            [XmlElement(ElementName = "last-search-date")]
            public string Lastsearchdate { get; set; }
            [XmlElement(ElementName = "nature-of-business")]
            public string Natureofbusiness { get; set; }
            [XmlElement(ElementName = "ErrorMsg")]
            public string ErrorMsg { get; set; }
            [XmlElement(ElementName = "WarningMsg")]
            public string WarningMsg { get; set; }
            [XmlElement(ElementName = "bureau-reference")]
            public string Bureaureference { get; set; }
            [XmlElement(ElementName = "bca-company-type")]
            public string Bcacompanytype { get; set; }
            [XmlElement(ElementName = "bca-name")]
            public string Bcaname { get; set; }
        }
        [XmlRoot(ElementName = "org-id-result")]
        public class Orgidresult
        {
            [XmlElement(ElementName = "match-name")]
            public string Matchname { get; set; }
            [XmlElement(ElementName = "organisation-number")]
            public string Organisationnumber { get; set; }
            [XmlElement(ElementName = "organisation-type")]
            public string Organisationtype { get; set; }
            [XmlElement(ElementName = "australian-business-number")]
            public string Australianbusinessnumber { get; set; }
            [XmlElement(ElementName = "organisation-number-heading")]
            public string Organisationnumberheading { get; set; }
            [XmlElement(ElementName = "state")]
            public string State { get; set; }
            [XmlElement(ElementName = "asic-report")]
            public Asicreport Asicreport { get; set; }
            [XmlElement(ElementName = "australian-business-register-report")]
            public Australianbusinessregisterreport Australianbusinessregisterreport { get; set; }
            [XmlElement(ElementName = "bureau-report")]
            public Bureaureport Bureaureport { get; set; }
        }
        [XmlRoot(ElementName = "response")]
        public class Response
        {
            [XmlElement(ElementName = "org-id-result")]
            public Orgidresult Orgidresult { get; set; }
            [XmlAttribute(AttributeName = "version")]
            public string Version { get; set; }
        }
        [XmlRoot(ElementName = "BCAservice-data")]
        public class BCAservicedata
        {
            [XmlElement(ElementName = "response")]
            public Response Response { get; set; }
        }
        [XmlRoot(ElementName = "BCAservice")]
        public class BCAservice
        {
            [XmlElement(ElementName = "BCAservice-code")]
            public string BCAservicecode { get; set; }
            [XmlElement(ElementName = "BCAservice-code-version")]
            public string BCAservicecodeversion { get; set; }
            [XmlElement(ElementName = "BCAservice-client-ref")]
            public string BCAserviceclientref { get; set; }
            [XmlElement(ElementName = "BCAservice-data")]
            public BCAservicedata BCAservicedata { get; set; }
        }
        [XmlRoot(ElementName = "BCAservices")]
        public class BCAservices
        {
            [XmlElement(ElementName = "BCAservice")]
            public BCAservice BCAservice { get; set; }
        }
        [XmlRoot(ElementName = "BCAmessage")]
        public class BCAmessage
        {
            [XmlElement(ElementName = "BCAservices")]
            public BCAservices BCAservices { get; set; }
            [XmlAttribute(AttributeName = "service-request-id")]
            public string Servicerequestid { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
        }
    }
