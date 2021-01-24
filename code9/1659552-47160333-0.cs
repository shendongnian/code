    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication13
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement cms = doc.Descendants("CMS").FirstOrDefault();
                XElement device = cms.Element("Device");
                
                Device.RecursiveParseXml(device, Device.root);
     
            }
        }
        public class Device
        {
            public static Device root = new Device();
            public List<Port> ports { get; set; }
            
            public string name { get; set; }
            public string type { get; set; }
            public string tb { get; set; }
            public string deviceConnectedToPort { get; set; }
            public Dictionary<string, string> properties { get; set; }
            public static void RecursiveParseXml(XElement parent, Device device)
            {
                device.name = (string)parent.Attribute("Name");
                device.type = (string)parent.Attribute("Type");
                device.tb = (string)parent.Attribute("TB");
                device.deviceConnectedToPort = (string)parent.Attribute("DeviceConnectedToPort");
                string strProperties = (string)parent.Attribute("properties");
                if (strProperties != null)
                {
                    string[] propertyArray = strProperties.Split(new char[] { ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string pattern = @"'(?'name'[^']+)':\s+'(?'value'[^']+)";
                    device.properties = new Dictionary<string, string>();
                    foreach (string property in propertyArray)
                    {
                        Match match = Regex.Match(property, pattern);
                        device.properties.Add(match.Groups["name"].Value, match.Groups["value"].Value);
                    }
                }
                foreach (XElement element in parent.Elements())
                {
                    Port newPort = new Port();
                    if (device.ports == null)
                    {
                        device.ports = new List<Port>();
                    }
                    device.ports.Add(newPort);
                    newPort.connectBy = (string)element.Attribute("Connected_BY");
                    XElement newDevice = element.Element("Device");
                    if (newDevice != null)
                    {
                        newPort.device = new Device();
                        RecursiveParseXml(element.Element("Device"), newPort.device);
                    }
                }
            }
        }
        public class Port
        {
            public string name { get; set; }
            public string connectBy { get; set; }
            public Device device { get; set; }
        }
     
    }
