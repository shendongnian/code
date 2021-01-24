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
                var orders = doc.Descendants("Orders_Renewals").Select(x => new {
                    file_line_number = (int)x.Element("file_line_number"),
                    issn = (string)x.Element("issn"),
                    reference = (string)x.Element("publisher_title_reference"),
                    title = (string)x.Element("journal_title"),
                    subscription = (string)x.Element("publisher_subscription_reference"),
                    agent = (int)x.Element("agent_subscription_reference")
                }).ToList();
            int agentRefNbr = 86031;
            var results = orders.Where(x => x.agent == agentRefNbr).ToList();
            }
        }
    }
