    using System.IO;
    using System.Xml;
            public static void ReadInnerText()
        {
            StreamWriter file = new StreamWriter("myTextFile.txt");
            file.WriteLine("log-date|service-name|request-id|groupID|ClientName|BrokerLoginName|FullName");
            string Line = string.Empty;
            string BrokerLoginName = string.Empty;
            XmlDocument doc = new XmlDocument();
            XmlNodeList SecondTag;
            XmlNodeList ThirdTag;
            XmlNodeList FourthTag;
            XmlNodeList FifthTag;
            doc.Load("inputFile.xml");
            XmlNodeList elemList = doc.GetElementsByTagName("request");
            foreach (XmlNode firstNode in elemList)
            {
                SecondTag = firstNode.ChildNodes;
                foreach (XmlNode SecondNode in SecondTag)
                {
                    if (SecondNode.Name.Equals("log-date"))
                    {
                        Line = SecondNode.InnerText + "|";
                    }
                    if (SecondNode.Name.Equals("service-name"))
                    {
                        Line = Line + SecondNode.InnerText + "|";
                    }
                    if (SecondNode.Name.Equals("request-id"))
                    {
                        Line = Line + SecondNode.InnerText + "|";
                    }
                    ThirdTag = SecondNode.ChildNodes;
                    foreach (XmlNode ThirdNode in ThirdTag)
                    {
                        FourthTag = ThirdNode.ChildNodes;
                        foreach (XmlNode FourthNode in FourthTag)
                        {
                            if (FourthNode.Name.Equals("GroupID"))
                            {
                                Line = Line + FourthNode.InnerText + "|";
                            }
                            if (FourthNode.Name.Equals("GroupName"))
                            {
                                Line = Line + FourthNode.InnerText + "|";
                            }
                            if (FourthNode.Name.Equals("ClientName"))
                            {
                                Line = Line + FourthNode.InnerText + "|";
                            }
                            FifthTag = FourthNode.ChildNodes;
                            foreach (XmlNode FifthNode in FifthTag)
                            {
                                if (FifthNode.Name.Equals("BrokerLoginName"))
                                {
                                    BrokerLoginName = FifthNode.InnerText + "|";
                                }
                                if (FifthNode.Name.Equals("FullName"))
                                {    
                                    file.WriteLine(Line+BrokerLoginName+FifthNode.InnerText);
                                }
                            }
                        }
                    }
                }
            }
            file.Close();
        }
