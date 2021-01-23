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
                var results = doc.Descendants("nts").Select(x => new
                {
                    id = (string)x.Element("Id"),
                    name = (string)x.Element("Name"),
                    round = x.Elements("Round").Select(y => new {prodDate = (DateTime)y.Element("prodDate"), roundDue = (decimal)y.Element("roundDue")})
                       .Where(y => y.roundDue > 0 && y.prodDate < DateTime.Now).OrderBy(y => DateTime.Now - y.prodDate).FirstOrDefault()
                }).FirstOrDefault();
            }
        }
    }
