    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication16
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                //Note : new DataTime gives a date of 1/1/1900.  Any valid date should be much closer to actual compare date
                var results = doc.Descendants("nts").Select(x => new
                {
                    id = (string)x.Element("Id"),
                    name = (string)x.Element("Name"),
                    round = x.Elements("Round").Select(y => new { prodDate = (object)y.Element("prodDate") == null ? new DateTime() : (DateTime)y.Element("prodDate") , roundDue = (decimal)y.Element("roundDue") })
                       .Where(y => y.roundDue > 0 && y.prodDate < DateTime.Now).OrderBy(y => DateTime.Now - y.prodDate).FirstOrDefault()
                }).FirstOrDefault();
            }
        }
    }
