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
                reader.ReadToFollowing("SubNetwork", "generic.xsd");
                Network.network.name =  reader.GetAttribute("id");
                Network.network.subnetworks = new List<SubNetwork>();
                reader.ReadToFollowing("SubNetwork", "generic.xsd");
                SubNetwork subNetWork = new SubNetwork();
                Network.network.subnetworks.Add(subNetWork);
                subNetWork.name =  reader.GetAttribute("id");
                subNetWork.sites = new List<Sites>(); 
                Sites newSite = null;
                while (!reader.EOF)
                {
                    if (!reader.Name.Contains("VsDataContainer"))
                    {
                        reader.ReadToFollowing("VsDataContainer", "generic.xsd");
                    }
                    if (!reader.EOF)
                    {
                        XElement vsDataContainer = (XElement)XElement.ReadFrom(reader);
                        XElement vsDataENodeBFunction = vsDataContainer.Descendants().Where(a => a.Name.LocalName == "vsDataENodeBFunction").FirstOrDefault();
                        if (vsDataENodeBFunction != null)
                        {
                            newSite = new Sites();
                            subNetWork.sites.Add(newSite);
                            XElement  eNBId = vsDataContainer.Descendants().Where(a => a.Name.LocalName == "eNBId").FirstOrDefault();
                            if (eNBId != null)
                            {
                                newSite.eNBId = (int)eNBId;
                            }
                        }
                        XElement vsDataEUtranCellFDD = vsDataContainer.Descendants().Where(a => (a.Name.LocalName == "vsDataType") && ((string)a == "vsDataEUtranCellFDD")).FirstOrDefault();
                        if (vsDataEUtranCellFDD != null)
                        {
                            CellName newCellName = new CellName() {
                                id = (string)vsDataContainer.Attribute("id"),
                                earfcndl = (int)vsDataContainer.Descendants().Where(a => a.Name.LocalName == "earfcndl").FirstOrDefault(),
                                earfcnul = (int)vsDataContainer.Descendants().Where(a => a.Name.LocalName == "earfcnul").FirstOrDefault()
                            };
                            if (newSite.cellName == null)
                            {
                                newSite.cellName = new List<CellName>();
                            }
                            newSite.cellName.Add(newCellName);
                        }
     
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
