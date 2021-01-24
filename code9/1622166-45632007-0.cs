    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication72
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XML));
                XML xml = new XML();
                xml.customers = new CustData();
                xml.customers.addressList = new AddressList();
                xml.customers.addressList.custAddr = new CustAddr();
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, xml);
                writer.Flush();
                writer.Close();
            }
        }
        public class XML
        {
            [XmlElement("Customers")]
            public CustData customers { get; set; }
        }
        [XmlRoot("Customers")]
        public class CustData
        {
            public DateTime WedAnniv { get; set; }
            public string Locality { get; set; }
            public string HomePhone { get; set; }
            public DateTime BirthDate { get; set; }
            public string Town { get; set; }
            public string Code { get; set; }
            public string Country { get; set; }
            public DateTime DtOfCreation { get; set; }
            public string Email { get; set; }
            public string StreetAddr { get; set; }
            public Boolean IsMale { get; set; }
            public string MobilePhone { get; set; }
            public string Nm { get; set; }
            public string PostalCd { get; set; }
            public string State { get; set; }
            [XmlElement("AddressList")]
            public AddressList addressList { get; set; }
        }
        [XmlRoot("AddressList")]
        public class AddressList
        {
            [XmlElement("CustAddr")]
            public CustAddr custAddr { get; set; }
        }
        [XmlRoot("CustAddr")]
        public class CustAddr
        {
            public string Addr1  { get; set; }
            public string AddressType { get; set; }
            public string City  { get; set; }
            public string MobilePhone  { get; set; }
            public string Country  { get; set; }
            public DateTime DateInsert { get; set; }
            public string Code { get; set; }
            public string Email { get; set; }
            public string Contact { get; set; }
            public Boolean IsBillingAddress  { get; set; }
            public string DefaultAddress { get; set; }
            public double Lat { get; set; }
            public string Locality { get; set; }
            public double Long { get; set; }
            public string PostalCd { get; set; }
            public string State { get; set; }
        }
        
    }
     
