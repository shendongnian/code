    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication72
    {
        class Program
        {
            static void Main(string[] args)
            {
                string root = "<StructureMetaData xsi:schemaLocation=\"MSD\" xmlns=\"MSD\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"></StructureMetaData>";
                XDocument doc = XDocument.Parse(root);
                XElement metaData = doc.Root;
                XNamespace ns = metaData.GetDefaultNamespace();
                metaData.Add(new XElement(ns + "ABC", new object[] {
                    new XElement(ns + "DEF", new object[] {
                        new XAttribute("rst","abc"),
                        123}),
                    new XElement(ns + "GHI", new object[] {
                        new XAttribute("uvw","def"),                    
                        456}),
                    new XElement(ns + "JKL", new object[] {
                        new XAttribute("xyz","ghi"),
                        789})
                }));
                doc.Save("filename");
            }
        }
    }
