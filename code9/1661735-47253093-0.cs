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
            const string URL = "http://www.boi.org.il/currency.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                Currency.currencies = doc.Descendants("CURRENCY").Select(x => new Currency() {
                    name = (string)x.Element("NAME"),
                    unit = (int)x.Element("UNIT"),
                    code = (string)x.Element("CURRENCYCODE"),
                    country = (string)x.Element("COUNTRY"),
                    rate = (decimal)x.Element("RATE"),
                    change = (decimal)x.Element("CHANGE")
                }).ToList();
            }
        }
        public class Currency
        {
            public static List<Currency> currencies = new List<Currency>();
            public string name { get; set; }
            public int unit { get; set; }
            public string code { get; set; }
            public string country { get; set; }
            public decimal rate { get; set; }
            public decimal change { get; set; }
        }
    }
