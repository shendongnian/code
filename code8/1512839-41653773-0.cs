    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlHeader =
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<Osoba xmlns:dfs=\"http://schemas.microsoft.com/office/infopath/2003/dataFormSolution\"" +
                        " xmlns:pc=\"http://schemas.microsoft.com/office/infopath/2007/PartnerControls\"" + 
                        " xmlns:d=\"http://schemas.microsoft.com/office/infopath/2009/WSSList/dataFields\">" +
                    "</Osoba>";
                XDocument doc = XDocument.Parse(xmlHeader);
                XElement osoba = doc.Root;
                XNamespace dfsNs = osoba.GetNamespaceOfPrefix("dfs");
                XNamespace pcNs = osoba.GetNamespaceOfPrefix("pc");
                osoba.Add(new XElement(pcNs + "tehe", new object[] {
                    new XElement(dfsNs + "raz", "dfdfdfdf"),
                    new XElement(dfsNs + "dwa", "fgfg")
                }));
            }
        }
    }
