    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ProgrammingBasics
    {
        class Exercise
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main()
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants().Where(x => x.Name.LocalName == "Benchmark").Select(y => new
                {
                    title = (string)y.Elements().Where(z => z.Name.LocalName == "title").FirstOrDefault()
                }).FirstOrDefault();
            }
     
        }
        
    }
