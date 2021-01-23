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
                try
                {
                    string testData = @"<?xml version=""1.0""?>
                                    <SSPReturnMessage>
                                            <DeviceList>
                                                <Device SN=""RX1"">
                                                <PL N=""XYZ"" Vn=""PQR""/>
                                                <IP> 192.168.201.248 </IP >
                                               <DN><![CDATA[device name]]></DN>
                                                </Device>
                                            </DeviceList>
                                    </SSPReturnMessage>";
                    XDocument xDoc = XDocument.Parse(testData);
                    var devices = xDoc.Descendants("Device")
                    .Select(x =>
                        new Device
                        {
                            DeviceName = x.Element("IP").Value,
                            IP = x.Element("DN").Value,
                        }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();
            }
     
        }
        public class Device
        {
            private string _deviceName;
            private string _ip;
            public Device() { } //added
            public Device(string ip, string deviceName)
            {
                _ip = ip;
                _deviceName = deviceName;
            }
            public string DeviceName
            {
                get { return _deviceName; }
                set { _deviceName = value;}  //added
            }
            public string IP
            {
                get { return _ip; }
                set { _ip = value; }  //added
            }
        }
    }
