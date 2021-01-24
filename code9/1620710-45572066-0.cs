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
                metaData.Add("ABC", new object[] {
                    new XElement("DEF", 123),
                    new XElement("GHI", 456),
                    new XElement("JKL", 789)
                });
                doc.Save("filename");
            }
        }
    }
