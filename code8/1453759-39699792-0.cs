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
                foreach (XElement detail in doc.Descendants("Details"))
                {
                    detail.Add(new object[] {
                        new XElement("LTime", DateTime.Now.ToString("hh:mm:ss")),
                        new XElement("FDate", DateTime.Now.Date.ToShortDateString())
                    });
                }
            }
        }
    }
