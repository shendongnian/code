                Org.LLRP.LTK.LLRPV1.DataType.Message obj;
                ENUM_LLRP_MSG_TYPE msg_type;
                // read the XML from a file and validate its an SET_READER_CONFIG
                try
                {
                    FileStream fs = new FileStream(@"setReaderConfig.xml", FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    string s = sr.ReadToEnd();
                    fs.Close();
                    LLRPXmlParser.ParseXMLToLLRPMessage(s, out obj, out msg_type);
                    if (obj == null || msg_type != ENUM_LLRP_MSG_TYPE.SET_READER_CONFIG)
                    {
                        Console.WriteLine("Could not extract message from XML");
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Unable to convert to valid XML");
                    return;
                }
                // Communicate that message to the reader
                MSG_SET_READER_CONFIG msg = (MSG_SET_READER_CONFIG)obj;
