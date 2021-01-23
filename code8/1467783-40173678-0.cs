    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication21
    {
        class Program
        {
            const string FILEName = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILEName);
                XElement caseList = doc.Descendants().Where(x => x.Name.LocalName == "caseList").FirstOrDefault();
                XNamespace ns = caseList.GetDefaultNamespace();
                var results = caseList.Descendants(ns + "case").Select(x => new {
                    masterData = x.Descendants(ns + "masterData").Select(y => new {
                        age = y.Descendants(ns + "age").Select(z => z.IsEmpty  ? null : (int?)z).FirstOrDefault(),
                        sex = (int?)y.Descendants(ns + "sex").FirstOrDefault(),
                        asa = (int?)y.Descendants(ns + "asa").FirstOrDefault(),
                        cause = (int?)y.Descendants(ns + "cause").FirstOrDefault(),
                        trauma = (int?)y.Descendants(ns + "trauma").FirstOrDefault(),
                        date = (DateTime) y.Descendants(ns + "date").FirstOrDefault() + ((DateTime)(y.Descendants(ns + "time").FirstOrDefault())).TimeOfDay,
                    }).FirstOrDefault(),
                    preClinicalData = x.Descendants(ns + "masterData").Select(y => new {
                        alarm = (DateTime) y.Descendants(ns + "date").FirstOrDefault() + ((DateTime)(y.Descendants(ns + "time").FirstOrDefault())).TimeOfDay,
                        arrival = (DateTime)y.Descendants(ns + "date").FirstOrDefault() + ((DateTime)(y.Descendants(ns + "time").FirstOrDefault())).TimeOfDay,
                        departure = (DateTime)y.Descendants(ns + "date").FirstOrDefault() + ((DateTime)(y.Descendants(ns + "time").FirstOrDefault())).TimeOfDay,
                        capnometry = (int?)x.Descendants(ns + "capnometry").FirstOrDefault(),
                        mmHg = (int?)x.Descendants(ns + "mmHg").FirstOrDefault(),
                        heartRate = (int?)x.Descendants(ns + "heartRate").FirstOrDefault(),
                        respiratoryRate = (int?)x.Descendants(ns + "respiratoryRate").FirstOrDefault(),
                        oxygenSaturation = (int?)x.Descendants(ns + "oxygenSaturation").FirstOrDefault(),                    
                    }).FirstOrDefault()
                }).ToList();
            }
        }
    }
