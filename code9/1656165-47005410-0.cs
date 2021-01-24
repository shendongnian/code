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
                var results = doc.Descendants("message").Select(x => new {
                    messageId = (int)x.Element("messageId"),
                    serverId = (string)x.Element("serverId"),
                    channelId = (string)x.Element("channelId"),
                    time = (long)x.Descendants("time").FirstOrDefault(),
                    connectorMessages = x.Descendants("connectorMessage").Select(y => new {
                        messageId = (int)y.Descendants("messageId").FirstOrDefault(),
                        raw = y.Elements("raw").Select(z => new {
                            encrypted = (bool)z.Element("encrypted"),
                            channelId = (string)z.Element("channelId"),
                            messagedId = (int)z.Element("messageId"),
                            metaDataId = (string)z.Element("metaDataId"),
                            contentType = (string)z.Element("contentType")
                        }).FirstOrDefault(),
                        response = y.Elements("response").Select(z => new {
                            encrypted = (bool)z.Element("encrypted"),
                            channelId = (string)z.Element("channelId"),
                            messagedId = (int)z.Element("messageId"),
                            metaDataId = (string)z.Element("metaDataId")
                        }).FirstOrDefault(),
                        entries = y.Descendants("entry").Select(z => new {
                                strings = z.Elements("string").Select(b => (string)b).ToList()
                        }).ToList()
                    }).ToList()
                }).ToList();
                  
            }
        }
    }
