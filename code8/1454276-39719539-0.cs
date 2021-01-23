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
            static void Main(string[] args)
            {
                XDocument sampleDoc = XDocument.Load(@"c:\temp\sample.xml");
                XDocument dbDoc = XDocument.Load(@"c:\temp\dbfile.xml");
                var merge =
                      (from db in dbDoc.Descendants("Data")
                       join sample in sampleDoc.Descendants("Details") on new { id = (int)db.Element("Id"), name = (string)db.Element("Name") } equals new { id = (int)sample.Element("Id"), name = (string)sample.Element("Name") }
                       select new { db = db, sample = sample });
                foreach (var row in merge)
                {
                    row.db.Add(new object[] {
                        row.sample.Element("Date"),
                        row.sample.Element("Time")
                    });
                }
            }
        }
    }
