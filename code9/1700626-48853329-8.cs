            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                XmlNode[] identity = new XmlNode[] { doc.CreateTextNode("sender@sendercompany.com")};
                XmlNode[] sharedSecret = new XmlNode[] { doc.CreateTextNode("abracadabra") };
                Header header = new Header()
                {
                    Sender = new Sender()
                    {
                        Credential = new Credential[] {
                            new Credential() { 
                                domain = "AribaNetworkUserId",
                               Identity = new Identity() { Any =  identity },
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
