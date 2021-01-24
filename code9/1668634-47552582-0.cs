    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication14
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                var response = doc.Elements("Response").Select(x => new
                {
                    type = (string)x.Attribute("type"),
                    code = (int)x.Element("ResponseCode"),
                    status = (string)x.Element("ResponseStatus"),
                    message = x.Descendants("Account").Select(y => new
                    {
                        name = (string)y.Attribute("Name"),
                        avBal = (string)y.Attribute("AvBal"),
                        resBal = (string)y.Attribute("ResBal"),
                        currency = (string)y.Attribute("Currency"),
                        localBalance = (string)y.Attribute("LocalBalance"),
                        defaultw = (Boolean)y.Attribute("defaultW")
                    }).ToList()
                }).FirstOrDefault();
            }
      
        }
    }
