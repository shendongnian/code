    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication48
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);  //use parse instead if input is a string
                PartInfo partInfo = doc.Elements("Part").Select(x => new PartInfo()
                {
                    ItemId = (string)x.Element("ItemId"),
                    ItemDescription = (string)x.Element("ItemDescription"),
                    Cost = (decimal)x.Element("Cost"),
                    Weight = (double)x.Element("Weight")
                }).FirstOrDefault();
     
            }
        }
        public class PartInfo
        {
            public string ItemId { get; set; }
            public string ItemDescription { get; set; }
            public decimal Cost { get; set; }
            public double Weight { get; set; }
        }
    }
