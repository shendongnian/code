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
                XElement dialogs = doc.Descendants().Where(x => x.Name.LocalName == "dialogs").FirstOrDefault();
                XNamespace ns = dialogs.GetDefaultNamespace();
                var results = dialogs.Elements(ns + "Dialog").Select(x => new {
                    id = (int)x.Element(ns + "id"), 
                    associatedDialogUri = (string)x.Element(ns + "associatedDialogUri"),
                    fromAddress = (string)x.Element(ns + "fromAddress"),
                    dnis = (int)x.Descendants(ns + "DNIS").FirstOrDefault(),
                    callType = (string)x.Descendants(ns + "callType").FirstOrDefault(),
                    dialedNumber = (int)x.Descendants(ns + "dialedNumber").FirstOrDefault(),
                    outboundClassification = (string)x.Descendants(ns + "outboundClassification").FirstOrDefault(),
                    callVariables = x.Descendants(ns + "CallVariable").Select(y => new {
                        name = (string)y.Element(ns + "name"),
                        value = (string)y.Element(ns + "value")
                    }).ToList(),
                    participants = x.Descendants(ns + "Participant").Select(y => new
                    {
                        actions = y.Descendants(ns + "action").Select(z => (string)z).ToList(),
                        namemediaAddress = (int)y.Element(ns + "mediaAddress"),
                        mediaAddressType = (string)y.Element(ns + "mediaAddressType"),
                        startTime = (DateTime)y.Element(ns + "startTime"),
                        state = (string)y.Element(ns + "state"),
                        stateCause = (string)y.Element(ns + "stateCause"),
                        stateChangeTime = (DateTime)y.Element(ns + "stateChangeTime")
                    }).ToList(),
                    state = (string)x.Descendants(ns + "state").FirstOrDefault(),
                    toAddress = (int)x.Descendants(ns + "toAddress").FirstOrDefault(),
                    uri = (string)x.Descendants(ns + "uri").FirstOrDefault()
                }).ToList();
            }
        }
    }
