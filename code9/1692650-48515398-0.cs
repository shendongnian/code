    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XElement doc = XElement.Parse(xml);
                var results = doc.Descendants("SaldosCaptacion").Select(x => new {
                    Cuenta = (string)x.Element("Cuenta"),
                    SaldoActual = (decimal)x.Element("SaldoActual")
                }).ToList();
            }
        }
    }
