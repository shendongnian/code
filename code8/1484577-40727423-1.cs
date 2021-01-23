    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication28
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<Root>" +
                        "<transaction>" +
                            "<institution>34439</institution>" +
                            "<account_no>10000</account_no>" +
                            "<type>2</type>" +
                            "<amount>50</amount>" +
                            "<notes>withdrawal</notes>" +
                        "</transaction>" +
                        "<transaction>" +
                            "<institution>34440</institution>" +
                            "<account_no>10001</account_no>" +
                            "<type>2</type>" +
                            "<amount>50</amount>" +
                            "<notes>withdrawal</notes>" +
                        "</transaction>" +
                    "</Root>";
                XDocument doc = XDocument.Parse(xml);
                List<XElement> tranactions = doc.Descendants("transaction").ToList();
                var results = tranactions.Where(x => (int)x.Element("account_no") == 10000).Any(); 
     
            }
        }
    }
