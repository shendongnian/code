    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string CURRENCY_FILE = @"c:\temp\test.xml";
            const string COUNTRY_FILE = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("NUMCODE", typeof(int));
                dt.Columns.Add("CHARCODE", typeof(string));
                dt.Columns.Add("Nominal", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Value", typeof(decimal));
                XDocument currencyXml = XDocument.Load(CURRENCY_FILE);
                List<XElement> valutes = currencyXml.Descendants("Valute").ToList();
                foreach (XElement valute in valutes)
                {
                    dt.Rows.Add(new object[] {
                        (int)valute.Attribute("ID"),
                        (int)valute.Element("NumCode"),
                        (string)valute.Element("CharCode"),
                        (int)valute.Element("Nominal"),
                        (string)valute.Element("Name"),
                        (decimal)valute.Element("Value")
                    });
                }
                XDocument countryXml = XDocument.Load(COUNTRY_FILE);
                List<string> countries = countryXml.Descendants("Cod").Select(x => (string)x).ToList();
                DataTable filteredTable = dt.AsEnumerable().Where(x => countries.Contains(x.Field<string>("CharCode"))).CopyToDataTable();
            }
        }
    }
