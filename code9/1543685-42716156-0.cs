    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication47
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("Customers").Select(x => new
                {
                    customerID = (string)x.Element("CustomerID"),
                    companyName = (string)x.Element("CompanyName"),
                    orders = x.Elements("Orders").Select(y => new {      
                       orderID = (int)y.Element("OrderID"),
                       customerID = (string)y.Element("CustomerID"),
                       date =  (DateTime)y.Element("OrderDate")
                    }).ToList()
                }).ToList();
            }
        }
    }
