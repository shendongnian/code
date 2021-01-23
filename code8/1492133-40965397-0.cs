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
            static void Main(string[] args)
            {
                string[] trackingNumbers = {"5551212699300000962610", "5551212699300000962611", "5551212699300000962612"};
                XElement trackFieldRequest = new XElement("TrackFieldRequest", new object[] {
                    new XAttribute("PASSWORD", "password"),
                    new XAttribute("USERID", "prodsolclient"),
                    new XAttribute("APPID", ""),
                    new XElement("Revision",1),
                    new XElement("ClientIp", "111.0.0.1")
                });
                foreach (string trackingNumber in trackingNumbers)
                {
                    trackFieldRequest.Add(new XElement("TrackID", trackingNumber));
                }
                string xml = trackFieldRequest.ToString();
            }
        }
    }
