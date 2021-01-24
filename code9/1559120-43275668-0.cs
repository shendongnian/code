    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {   
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new Sampleclass(FILENAME);
            }
        }
        public class Sampleclass
        {
            public static HRootObject  hRootObject { get; set; }
            public Sampleclass(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XNamespace ns = ((XElement)doc.FirstNode).GetDefaultNamespace();
                hRootObject = doc.Elements(ns + "OTA_HotelInvCountNotifRQ").Select(m => new HRootObject() {
                    TimeStamp = (DateTime)m.Attribute("TimeStamp"),
                    Version = (string)m.Attribute("Version"),
                     Inventories = m.Elements(ns + "Inventories").Select(n => new Inventories() {
                         HotelCode = (string)n.Attribute("HotelCode"),
                         Inventory = n.Elements(ns + "Inventory").Select(o => new Inventory() {
                             StatusApplicationControl = o.Elements(ns + "StatusApplicationControl").Select(p => new StatusApplicationControl() {
                                 Start = (DateTime)p.Attribute("Start"),
                                 End = (DateTime)p.Attribute("End"),
                                 Mon = (int)p.Attribute("Mon"),
                                 Tue = (int)p.Attribute("Tue"),
                                 Wed = (int)p.Attribute("Wed"),
                                 Thur = (int)p.Attribute("Thur"),
                                 Fri = (int)p.Attribute("Fri"),
                                 Sat = (int)p.Attribute("Sat"),
                                 Sun = (int)p.Attribute("Sun"),
                                 InvTypeCode = (string)p.Attribute("InvTypeCode"),
                                 AllInvCode = (Boolean)p.Attribute("AllInvCode")
                             }).FirstOrDefault(),
                             InvCounts = o.Elements(ns + "InvCounts").Select(p => new InvCounts() {
                                 InvCount = p.Elements(ns + "InvCount").Select(q => new InvCount() {
                                     Count = (int)q.Attribute("Count"),
                                     CountType = (int)q.Attribute("CountType")
                                 }).FirstOrDefault()
                             }).FirstOrDefault()
                         }).ToList()
                     }).FirstOrDefault()
                }).FirstOrDefault();
            }
                    
            public class StatusApplicationControl
            {
                public DateTime Start { get; set; }
                public DateTime End { get; set; }
                public int Mon { get; set; }
                public int Tue { get; set; }
                public int Wed { get; set; }
                public int Thur { get; set; }
                public int Fri { get; set; }
                public int Sat { get; set; }
                public int Sun { get; set; }
                public string InvTypeCode { get; set; }
                public Boolean AllInvCode { get; set; }
            }
            public class InvCount
            {
                public int CountType { get; set; }
                public int Count { get; set; }
            }
            public class InvCounts
            {
                public InvCount InvCount { get; set; }
            }
            public class Inventory
            {
                public StatusApplicationControl StatusApplicationControl { get; set; }
                public InvCounts InvCounts { get; set; }
            }
            public class Inventories
            {
                public string HotelCode { get; set; }
                public List<Inventory> Inventory { get; set; }
            }
            public class HRootObject
            {
                public DateTime TimeStamp { get; set; }
                public string Version { get; set; }
                public Inventories Inventories { get; set; }
            }
        }
     
       
    }
