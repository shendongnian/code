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
                        newNetwork.subnetworks = XNetwork.Elements().Where(x => x.Name.LocalName == "SubNetwork").Select(x => new SubNetwork()
                        {
                            name = (string)x.Attribute("id"),
                            sites = x.Descendants().Where(y => y.Name.LocalName == "MeContext").Select(y => new Sites() {
                                sitename = (string)y.Attribute("id"),
                                eNBId = y.Descendants().Where(z => (z.Name.LocalName == "VsDataContainer") && (z.Descendants().Where(a => a.Name.LocalName == "vsDataENodeBFunction").Any())).Select(z => (int)y.Descendants().Where(a => a.Name.LocalName == "eNBId").Select(a => a).FirstOrDefault()).FirstOrDefault(),
                                cellName = y.Descendants().Where(z => (z.Name.LocalName == "VsDataContainer") && (z.Descendants().Where(a => a.Name.LocalName == "earfcndl").Any())).Select(z => new CellName() {
                                    id = (string)z.Attribute("id"),
                                    earfcndl = (int)z.Descendants().Where(a => a.Name.LocalName == "earfcndl").FirstOrDefault(),
                                    earfcnul = (int)z.Descendants().Where(a => a.Name.LocalName == "earfcnul").FirstOrDefault()
                                }).ToList()
                            }).ToList()
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
            public List<Sites> sites { get; set; }
        }
        public class Sites
        {
            public string sitename { get; set; }
            public int eNBId { get; set; }
            public List<CellName> cellName { get; set; }
        }
        public class CellName
        {
            public string id { get; set; }
            public int earfcndl { get; set; }
            public int earfcnul { get; set; }
        }
    }
