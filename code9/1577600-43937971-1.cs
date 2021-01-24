    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication55
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("advertentie").Select(x => new
                {
                    uid = (int)x.Element("uId"),
                    merk = (string)x.Descendants("merk").FirstOrDefault(),
                    carrosserie = (string)x.Descendants("carrosserie").FirstOrDefault(),
                    laatsUpdate = (double)x.Descendants("laatsUpdate").FirstOrDefault(),
                    FotoGroot = x.Descendants("FotoGroot").Select(y => (string)y).ToList()
                }).ToList();
                string strings = results.Select(x => string.Join("</p>", new string[] {x.uid, x.merk, x.carrosserie, x.laatsUpdate, x.FotoGroot})
                    .Select(x => string.Join("</div>", x));
                
            }
        }
    }
