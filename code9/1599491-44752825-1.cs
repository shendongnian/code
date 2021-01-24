    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Data;
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
            public DataTable GetTable()
            {
                DataTable report = new DataTable();
                report.Columns.Add("asic-name", typeof(string));
                report.Columns.Add("asic-organisation-number", typeof(string));
                report.Columns.Add("asic-a-b-n", typeof(string));
                report.Columns.Add("asic-organisation-number-heading", typeof(string));
                report.Columns.Add("asic-type", typeof(string));
                report.Columns.Add("asic-status", typeof(string));
                report.Columns.Add("asic-jurisdiction", typeof(string));
                report.Columns.Add("asic-locality", typeof(string));
                report.Columns.Add("asic-address-state", typeof(string));
                report.Columns.Add("asic-postcode", typeof(string));
                report.Rows.Add(new object[] {
                    Asicname,
                    Asicorganisationnumber,
                    Asicabn,
                    Asicorganisationnumberheading,
                    Asictype,
                    Asicstatus,
                    Asicjurisdiction,
                    Asiclocality,
                    Asicaddressstate,
                    Asicpostcode
                });
                return report;
            }
        }
        [XmlRoot(ElementName = "australian-business-register-report")]
        public class Australianbusinessregisterreport
        {
            [XmlElement(ElementName = "ASICNumber")]
            public int ASICNumber { get; set; }
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
            public DataTable GetReport()
            {
                DataTable report = new DataTable();
                report.Columns.Add("ASICNumber", typeof(int));
                report.Columns.Add("ABN", typeof(string));
                report.Columns.Add("ABNStatus", typeof(string));
                report.Columns.Add("ABNStatusFromDate", typeof(string));
                report.Columns.Add("EntityTypeInd", typeof(string));
                report.Columns.Add("Non-IndividualName", typeof(string));
                report.Columns.Add("BusinessAddressState", typeof(string));
                report.Columns.Add("BusnessAddressPostcode", typeof(string));
                report.Columns.Add("GSTStatus", typeof(string));
                report.Columns.Add("GSTStatusFromDate", typeof(string));
                report.Columns.Add("TradingName", typeof(string));
                report.Rows.Add(new object[] {
                    ASICNumber,
                    ABN,
                    ABNStatus,
                    ABNStatusFromDate,
                    EntityTypeInd,
                    NonIndividualName,
                    BusinessAddressState,
                    BusinessAddressPostcode,
                    GSTStatus,
                    GSTStatusFromDate,
                    TradingName
                });
                return report;
            }
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
            public int Unitnumber { get; set; }
            [XmlElement(ElementName = "street-number")]
            public int Streetnumber { get; set; }
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
            public void GetReport(DataTable report, List<object> row)
            {
                report.Columns.Add("unit-number", typeof(int));
                report.Columns.Add("street-number", typeof(int));
                report.Columns.Add("property", typeof(string));
                report.Columns.Add("street-name", typeof(string));
                report.Columns.Add("Streettype-code", typeof(string));
                report.Columns.Add("Suburb", typeof(string));
                report.Columns.Add("state", typeof(string));
                report.Columns.Add("postcode", typeof(string));
                report.Columns.Add("first-reported", typeof(string));
                report.Columns.Add("type", typeof(string));
                row.AddRange(new object[] {
                    Unitnumber,
                    Streetnumber,
                    Property,
                    Streetname,
                    Streettype.Code,
                    Suburb,
                    State,
                    Postcode,
                    Firstreported,
                    Type
                });
            }
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
            public DataTable GetReport()
            {
                DataTable report = new DataTable();
                report.Columns.Add("last-search-date", typeof(string));
                report.Columns.Add("nature-of-business", typeof(string));
                report.Columns.Add("ErrorMsg", typeof(string));
                report.Columns.Add("WarmingMsg", typeof(string));
                report.Columns.Add("bureau-reference", typeof(string));
                report.Columns.Add("bca-name", typeof(string));
                List<object> row = new List<object>();
                Address.GetReport(report, row);
                row.AddRange(new object[] { 
                    Lastsearchdate,
                    Natureofbusiness,
                    ErrorMsg,
                    WarningMsg,
                    Bureaureference,
                    Bcaname
                });
                report.Rows.Add(row);
                
                return report;
            }
        }
        [XmlRoot(ElementName = "org-id-result")]
        public class Orgidresult
        {
            [XmlElement(ElementName = "match-name")]
            public string Matchname { get; set; }
            [XmlElement(ElementName = "organisation-number")]
            public long Organisationnumber { get; set; }
            [XmlElement(ElementName = "organisation-type")]
            public string Organisationtype { get; set; }
            [XmlElement(ElementName = "australian-business-number")]
            public long Australianbusinessnumber { get; set; }
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
            public DataTable GetReport()
            {
                DataTable report = new DataTable();
                report.Columns.Add("match-name", typeof(string));
                report.Columns.Add("organisation-number", typeof(long));
                report.Columns.Add("organistion-type", typeof(string));
                report.Columns.Add("australian-business-number", typeof(long));
                report.Columns.Add("organisation-number-header", typeof(string));
                report.Columns.Add("state", typeof(string));
                report.Columns.Add("Asicorganisationnumber", typeof(int));
                report.Columns.Add("ASICNumber", typeof(int));
                report.Columns.Add("Bcaname", typeof(string));
                report.Rows.Add(new object[] {
                    Matchname,
                    Organisationnumber,
                    Organisationtype,
                    Australianbusinessnumber,
                    State,
                    Asicreport.Asicorganisationnumber,
                    Australianbusinessregisterreport.ASICNumber,
                    Bureaureport.Bcaname
                });
                return report;
            }
        }
        [XmlRoot(ElementName = "response")]
        public class Response
        {
            [XmlElement(ElementName = "org-id-result")]
            public Orgidresult Orgidresult { get; set; }
            [XmlAttribute(AttributeName = "version")]
            public string Version { get; set; }
            public void GetReport(DataTable report, List<object> row)
            {
                report.Columns.Add("Organisationnumber", typeof(int));
                report.Columns.Add("Version", typeof(string));
                row.AddRange(new object[] {
                    Orgidresult.Organisationnumber,
                    Version
                });
            }
        }
        [XmlRoot(ElementName = "BCAservice-data")]
        public class BCAservicedata
        {
            [XmlElement(ElementName = "response")]
            public Response Response { get; set; }
            public void GetTable(DataTable report, List<object> row)
            {
                Response.GetReport(report, row );
            }
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
            public void GetReport(DataTable report, List<object> row)
            {
                report.Columns.Add("BCAservicecode", typeof(string));
                report.Columns.Add("BCAservicecodeversion", typeof(string));
                report.Columns.Add("BCAserviceclientref", typeof(string));
                report.Columns.Add("BCAservicedata", typeof(string));
                row.AddRange(new object[] {
                    BCAservicecode,
                    BCAservicecodeversion,
                    BCAserviceclientref,
                    BCAservicecode
                });
                BCAservicedata.GetTable(report, row);
            }
        }
        [XmlRoot(ElementName = "BCAservices")]
        public class BCAservices
        {
            [XmlElement(ElementName = "BCAservice")]
            public BCAservice BCAservice { get; set; }
            public void GetReport(DataTable report, List<object> row)
            {
                BCAservice.GetReport(report, row);
            }
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
            public DataTable GetReport()
            {
                DataTable report = new DataTable();
                List<object> row = new List<object>();
                report.Columns.Add("Sercicerequestid", typeof(string));
                report.Columns.Add("type", typeof(string));
                BCAservices.GetReport(report, row);
                row.AddRange(new object[] {
                    Servicerequestid,
                    Type
                });
                   
                return report;
            }
        }
    }
