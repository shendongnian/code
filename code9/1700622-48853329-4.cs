    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication23
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                XmlNode[] domain = new XmlNode[] { doc.CreateTextNode("AribaNetworkUserId")};
                domain[0].Value = "sender@sendercompany.com";
                XmlNode[] sharedSecret = new XmlNode[] { doc.CreateTextNode("abracadabra") };
                Header header = new Header()
                {
                    Sender = new Sender()
                    {
                        Credential = new Credential[] {
                            new Credential() { 
                               Identity = new Identity() { Any =  domain },
                               Item = new SharedSecret() { Any = sharedSecret }
                            }
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Header));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, header);
                writer.Flush();
                writer.Close();
            }
        }
    }
