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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xmlHeader =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>" +
                    "<!DOCTYPE isopackager PUBLIC" +
                    "        \"-//jPOS/jPOS Generic Packager DTD 1.0//EN\"" +
                    "        \"http://jpos.org/dtd/generic-packager-1.0.dtd\" >" +
                    "<!-- ISO 8583:1987 (ASCII) field descriptions for GenericPackager -->" +
                    "<isopackager>" +
                    "</isopackager>";
     
                
                //<isofield
                XDocument doc = XDocument.Parse(xmlHeader);
                XElement isoPackager = doc.Descendants("isopackager").FirstOrDefault();
                List<IsoField> isoFields = new List<IsoField>() {
                    new IsoField() { id= 0, length= 4, name="MESSAGE TYPE INDICATOR", cClass = "org.jpos.iso.IFA_NUMERIC"},
                    new IsoField() { id= 1, length= 16, name="BIT MAP", cClass= "org.jpos.iso.IFA_BITMAP"},
                    new IsoField() { id= 2, length= 19, name="PAN - PRIMARY ACCOUNT NUMBER", cClass= "org.jpos.iso.IFA_LLNUM"}
                    };
                foreach (IsoField isofield in isoFields)
                {
                    isoPackager.Add(new XElement("isofield", new object[] {
                        new XElement("id", isofield.id),
                        new XElement("length", isofield.length),
                        new XElement("name", isofield.name),
                        new XElement("class", isofield.cClass)
                    }));
                }
                doc.Save(FILENAME);
            }
        }
        public class IsoField
        {
            public int id {get; set;}
            public int length { get; set; }
            public string name { get; set; }
            public string cClass { get; set; }
        }
    }
