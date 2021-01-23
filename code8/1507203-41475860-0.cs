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
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> selectCmDeviceResult = doc.Descendants().Where(x => x.Name.LocalName == "SelectCmDeviceResult").ToList();
                var results = selectCmDeviceResult.Select(x => new {
                    selectCmDeviceResult = (int)x.Element("TotalDevicesFound"),
                    item = x.Element("CmNodes").Elements("item").Select(y => new {
                        returnCode = (string)y.Element("ReturnCode"),
                        name = (string)y.Element("Name"),
                        noChange = (Boolean)y.Element("NoChange"),
                        items = y.Element("CmDevices").Elements("item").Select(z => new {
                            name = (string)z.Element("Name"),
                            dirNumber = (string)z.Element("DirNumber"),
                            _class = (string)z.Element("Class"),
                            model = (int)z.Element("Model"),
                            product = (int)z.Element("Product"),
                            boxProduct = (int)z.Element("BoxProduct"),
                            httpd = (string)z.Element("Httpd"),
                            registrationAttempts = (int)z.Element("RegistrationAttempts"),
                            isCtiControllable = (Boolean)z.Element("IsCtiControllable"),
                            loginUserId = (string)z.Element("LoginUserId"),
                            status = (string)z.Element("Status"),
                            statusReason = (string)z.Element("StatusReason"),
                            perfMonObject = (int)z.Element("PerfMonObject"),
                            dChannel = (int)z.Element("DChannel"),
                            description = (string)z.Element("Description"),
                            timeStamp = (int)z.Element("TimeStamp"),
                            protocol = (string)z.Element("Protocol"),
                            numOfLines = (int)z.Element("NumOfLines"),
                            ipAddress = z.Elements("IPAddress").Select(a => new {
                                ip = (string)a.Descendants("IP").FirstOrDefault(),
                                ipAddressType = (string)a.Descendants("IPAddrType").FirstOrDefault(),
                                attribute = (string)a.Descendants("Attribute").FirstOrDefault()
                            }).FirstOrDefault()
                        }).ToList()
                    }).FirstOrDefault()
                }).FirstOrDefault();
            }
        }
    }
