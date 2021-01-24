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
                XElement bookingCreate = doc.Descendants().Where(x => x.Name.LocalName == "BookingCreate").FirstOrDefault();
                XNamespace ns = bookingCreate.GetDefaultNamespace();
                var results = doc.Descendants(ns + "BookingCreate").Select(x => new {
                    org = (string)x.Descendants(ns + "Org").FirstOrDefault(),
                    user = (string)x.Descendants(ns + "User").FirstOrDefault(),
                    password = (string)x.Descendants(ns + "Password").FirstOrDefault(),
                    language = (string)x.Descendants(ns + "Language").FirstOrDefault(),
                    currency = (string)x.Descendants(ns + "Currency").FirstOrDefault(),
                    testDebug = (Boolean)x.Descendants(ns + "TestDebug").FirstOrDefault(),
                    version = (string)x.Descendants(ns + "Version").FirstOrDefault(),
                    quoteId = (string)x.Element(ns + "QuoteId"),
                    guests = x.Descendants(ns + "Adult").Select(y => new {
                        title = (string)y.Attribute("title"),
                        first = (string)y.Attribute("first"),
                        last = (string)y.Attribute("last")
                    }).ToList(),
                    availability = (string)x.Descendants(ns + "AvailabilityStatus").FirstOrDefault(),
                    detailLevel = (string)x.Descendants(ns + "DetailLevel").FirstOrDefault()
                }).FirstOrDefault();
            }
        }
    }
