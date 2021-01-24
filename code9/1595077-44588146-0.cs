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
            static void Main(string[] args)
            {
                string xmlID = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Device Version=\"1.0\"></Device>";
                XDocument doc = XDocument.Parse(xmlID);
                XElement device = doc.Root;
                XElement packages = new XElement("Packages", new object[] {
                    new XElement("Package", new object[] {
                        new XAttribute("Manuf","TI"),
                        new XAttribute("ModelName","123"),
                        new XAttribute("MfgPartNumber","CSD86360"),
                        new XAttribute("Description","DEVICE_INFO"),
                        ".PartialCkt 123 ExtNode = 1 3 4 6\n" +
                        "V1 1 3 0\n" +
                        "V2 4 6 0 .EndPartialCkt"
                    })
                });
                device.Add(packages);
                XElement thermal = new XElement("Thermal", new object[] {
                    new XAttribute("Manuf","TI"),
                    new XAttribute("ModelName","123"),
                    new XAttribute("MfgPartNumber","CSD86360"),
                    new XAttribute("Description","DEVICE_INFO"),
                    new XAttribute("PowerDissipation","0.1W"),
                    new XAttribute("Material","2-Resistor CTM"),
                    new XAttribute("Thickness","1mm"),
                    new XAttribute("Theta_JB","1.5C/W"),
                    new XAttribute("Theta_JC","0C/W"),
                    new XAttribute("MaxDieTemperature","100C")
                });
                device.Add(thermal);
            }
        }
    }
