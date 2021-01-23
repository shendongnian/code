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
            enum State
            {
                GET_SUBNETWORK,
                GET_MECONTEXT,
                GET_CONTAINERS
            }
            static void Main(string[] args)
            {
                XmlReaderSettings settings = new XmlReaderSettings() { IgnoreWhitespace = true };
                XmlReader reader = XmlReader.Create(FILENAME, settings);
                reader.ReadToFollowing("SubNetwork", "generic.xsd");
                Network.network.name =  reader.GetAttribute("id");
                Network.network.subnetworks = new List<SubNetwork>();
                string xnNameSpace = reader.LookupNamespace("xn");
                reader.ReadToFollowing("SubNetwork", xnNameSpace);
                Sites newSite = null;
                SubNetwork subNetWork = null;
                Boolean endElement = false;
                State state = State.GET_SUBNETWORK;
                while (!reader.EOF)
                {
                    switch(state)
                    {
                        case State.GET_SUBNETWORK :
                            if (reader.Name != "xn:SubNetwork")
                            {
                                 reader.ReadToFollowing("SubNetwork", xnNameSpace);
                            }
                            if (!reader.EOF)
                            {
                                subNetWork = new SubNetwork();
                                Network.network.subnetworks.Add(subNetWork);
                                subNetWork.name = reader.GetAttribute("id");
                                subNetWork.sites = new List<Sites>();
                                state = State.GET_MECONTEXT;
                            }
                            break;
                        case State.GET_MECONTEXT :
                            if (reader.Name != "xn:MeContext")
                            {
                                if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    endElement = true;
                                    state = State.GET_SUBNETWORK;
                                }
                                else
                                {
                                    endElement = false;
                                    reader.ReadToFollowing("MeContext", xnNameSpace);
                                }
                            }
                            if (!reader.EOF && !endElement)
                            {
                                state = State.GET_CONTAINERS;
                                reader.ReadToFollowing("VsDataContainer", xnNameSpace);
                                newSite = null;
                            }
                            break;
                        case State.GET_CONTAINERS :
                            if (!reader.EOF)
                            {
                                switch (reader.NodeType)
                                {
                                    case XmlNodeType.EndElement:
                                        state = State.GET_SUBNETWORK;
                                        break;
                                    case XmlNodeType.Text:
                                        string text = reader.ReadContentAsString();
                                        break;
                                    case XmlNodeType.Element :
                                        string elementName = reader.Name;
                                        XElement element = (XElement)XElement.ReadFrom(reader);
                                        if (elementName == "xn:VsDataContainer")
                                        {
                                            XElement vsDataENodeBFunction = element.Descendants().Where(a => a.Name.LocalName == "vsDataENodeBFunction").FirstOrDefault();
                                            if (vsDataENodeBFunction != null)
                                            {
                                                if (newSite == null)
                                                {
                                                    newSite = new Sites();
                                                }
                                                subNetWork.sites.Add(newSite);
                                                XElement eNBId = element.Descendants().Where(a => a.Name.LocalName == "eNBId").FirstOrDefault();
                                                if (eNBId != null)
                                                {
                                                    newSite.eNBId = (int)eNBId;
                                                }
                                            }
                                            List<XElement> vsDataContainers = element.Descendants().Where(a => a.Name.LocalName == "VsDataContainer").ToList();
                                            List<XElement> vsDataEUtranCellFDD = vsDataContainers.Where(x => x.Descendants().Where(a => (a.Name.LocalName == "vsDataType") && ((string)a == "vsDataEUtranCellFDD")).Any()).ToList();
                                            if (vsDataEUtranCellFDD.Any())
                                            {
                                                List<CellName> cells = vsDataEUtranCellFDD.Select(x => new CellName() {
                                                    id = (string)x.Attribute("id"),
                                                    earfcndl = (int)x.Descendants().Where(a => a.Name.LocalName == "earfcndl").FirstOrDefault(),
                                                    earfcnul = (int)x.Descendants().Where(a => a.Name.LocalName == "earfcnul").FirstOrDefault()
                                                }).ToList();
                                                if (newSite == null)
                                                {
                                                    newSite = new Sites();
                                                }
                                                if (newSite.cellName == null)
                                                {
                                                    newSite.cellName = new List<CellName>();
                                                }
                                                newSite.cellName.AddRange(cells);
                                            }
                                        }
                                        break;
                                    default :
                                        Console.WriteLine("Unexpected Results");
                                        string elementText = reader.ReadContentAsString();
                                        Console.ReadLine();
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }
        public class Network
        {
            public static Network network = new Network();
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
