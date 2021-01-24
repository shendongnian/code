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
                XElement messageTags = XElement.Load(FILENAME);
                string header =
                    "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:eu=\"http://client.ws.emx.co.uk\">" +
                         "<soapenv:Header></soapenv:Header>" +
                         "<soapenv:Body>" +
                           "<eu:processXmlMessageRequest>" +
                           "</eu:processXmlMessageRequest>" +
                         "</soapenv:Body>" +
                    "</soapenv:Envelope>";
                XElement envelope = XElement.Parse(header);
                XElement request = envelope.Descendants().Where(x => x.Name.LocalName == "processXmlMessageRequest").FirstOrDefault();
                int sequenceNumber = 1;
                DateTime now = DateTime.Now;
                request.Add(new object[] {
                   new XElement("sequenceNumber", sequenceNumber),
                   new XElement("creationTime", now.ToString("yyyy-MM-ddT" + now.TimeOfDay.ToString())), //>2016-05-28T09:36:22.165</creationTime>
                   messageTags 
                });
            }
        }
    }
