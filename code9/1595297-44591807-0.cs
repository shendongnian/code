    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Order));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Order order = (Order)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("order")]
        public class Order
        {
            public int invoiceid { get; set; }
            private DateTime _invoicedate { get; set; }
            public string invoicedate
            {
                get { return  _invoicedate.ToString("d/m/yyyy");}
                set { _invoicedate = DateTime.ParseExact(value, "d/m/yyyy", CultureInfo.InvariantCulture); }
            }
            public int sellerid { get; set; }
            public int buyerid { get; set; }
            public int orderid { get; set; }
            [XmlElement("item")]
            public List<Item> items { get; set; }
            public decimal shippingcharges { get; set; }
            public decimal invoicetotalcost { get; set; } 
        }
        [XmlRoot("item")]
        public class Item
        {
            public int itemid { get; set; }
            public string itemname { get; set; }
            public string description { get; set; }
            public int quantity { get; set; }
            public decimal newunitprice { get; set; }
        }
    }
