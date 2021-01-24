    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlStr =
                    "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" >" +
                       "<SOAP-ENV:Body >" +
                          "<m:PingResponse xmlns:m=\"http://www.derbysoft.com/chapaai\"  />" +
                       "</SOAP-ENV:Body >" +
                    "</SOAP-ENV:Envelope >";
                XElement envelope = XElement.Parse(xmlStr);
                XElement response = envelope.Descendants().Where(x => x.Name.LocalName == "PingResponse").FirstOrDefault();
                response.Add(new XAttribute("Token", "E30ED3AA-65DE-48F9-BEA4-BA021B119625"));
                response.Add(new XAttribute("Echo", "Hello"));
                response.Add(new XAttribute("Status", "Successful"));
            }
            
        }
     
    }
