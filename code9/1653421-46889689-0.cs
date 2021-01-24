    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication10
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                DataTable dt = new DataTable();
                dt.Columns.Add("OrderID", typeof(string));
                dt.Columns.Add("storeID", typeof(int));
                dt.Columns.Add("paymentToken", typeof(int));
                dt.Columns.Add("transactionDateTime", typeof(DateTime));
                dt.Columns.Add("paymentTokenExiryDateTime", typeof(DateTime));
                dt.Rows.Add(new object[] {
                    (string)root.Descendants(ns + "orderId").FirstOrDefault(),
                    (int)root.Descendants(ns + "storeId").FirstOrDefault(),
                    (int)root.Descendants(ns + "paymentToken").FirstOrDefault(),
                    (DateTime)root.Descendants(ns + "transactionDateTime").FirstOrDefault(),
                    (DateTime)root.Descendants(ns + "paymentTokenExiryDateTime").FirstOrDefault()
                });
     
            }
        }
    }
