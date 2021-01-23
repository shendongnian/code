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
                var inportData = doc.Descendants("IMPORTDATA").Select(x => new {
                    reportName = (string)x.Descendants("REPORTNAME").FirstOrDefault(),
                    company = (string)x.Descendants("SVCURRENTCOMPANY").FirstOrDefault(),
                    remoteID = (string)x.Descendants("VOUCHER").FirstOrDefault().Attribute("REMOTEID"),
                    vchKey = (string)x.Descendants("VOUCHER").FirstOrDefault().Attribute("VCHKEY"),
                    date = DateTime.ParseExact((string)x.Descendants("DATE").FirstOrDefault(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture),
                    voucherName = (string)x.Descendants("VOUCHERTYPENAME").FirstOrDefault(),
                    voucherNumber = (int)x.Descendants("VOUCHERNUMBER").FirstOrDefault(),
                    ledgerName = (string)x.Descendants("PARTYLEDGERNAME").FirstOrDefault()
                }).FirstOrDefault();
            }
        }
    }
