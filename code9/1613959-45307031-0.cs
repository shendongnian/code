    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication68
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Order order = doc.Descendants("entity").Select(x => new Order()
                {
                    id = (long)x.Element("id"),
                    ordernumber = (string)x.Element("ordernumber"),
                    audits = x.Descendants("create").Select(y => (DateTime)y.Attribute("timestamp")).ToList()
                }).FirstOrDefault();
            }
        }
        public class Order
        {
            public long id { get; set; }
            public string ordernumber { get; set; }
            public List<DateTime> audits { get; set; }
        }   
     
    }
