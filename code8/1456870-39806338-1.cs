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
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (!reader.Name.Contains("SubNetwork"))
                    {
                        reader.ReadToFollowing("SubNetwork", "generic.xsd");
                    }
                    if (!reader.EOF)
                    {
                        XElement XNetwork = (XElement)XElement.ReadFrom(reader);
                        Network newNetwork = new Network();
                        Network.networks.Add(newNetwork);
                        newNetwork.name = (string)XNetwork.Attribute("id");
                        newNetwork.subnetworks = XNetwork.Elements().Where(x => x.Name.LocalName == "SubNetwork").Select(x => new SubNetwork() {
                            name = (string)x.Attribute("id"),
                            sitename = (string)x.Descendants().Where(y => y.Name.LocalName == "MeContext").FirstOrDefault().Attribute("id"),
                            eNBId = (int)x.Descendants().Where(y => (y.Name.LocalName == "VsDataContainer") && (y.Descendants().Where(z => z.Name.LocalName == "vsDataENodeBFunction").Any())).Select(y => (int)y.Attribute("id")).FirstOrDefault(),
                            cellname = x.Descendants().Where(y => (y.Name.LocalName == "VsDataContainer") && (y.Descendants().Where(z => z.Name.LocalName == "earfcndl").Any())).Select(y => new CellName() {
                                id = (string)y.Attribute("id"),
                                earfcndl = (int)y.Descendants().Where(z => z.Name.LocalName == "earfcndl").FirstOrDefault(),
                                earfcnul = (int)y.Descendants().Where(z => z.Name.LocalName == "earfcnul").FirstOrDefault()
                            }).FirstOrDefault()
                        }).ToList();
                    }
                }
            }
        }
        public class Network
        {
            public static List<Network> networks = new List<Network>();
            public string name { get; set; }
            public List<SubNetwork> subnetworks { get; set; }
        }
        public class SubNetwork
        {
            public string name { get; set; }
            public string sitename { get; set; }
            public int eNBId { get; set;}
            public CellName cellname { get; set; }
        }
        public class CellName
        {
            public string id { get; set;}
            public int earfcndl { get; set;}
            public int earfcnul { get; set;}
        }
    }
