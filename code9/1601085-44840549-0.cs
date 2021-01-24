                            string file = fileName;
                            System.Xml.XmlDocument xDoc = new 
                            System.Xml.XmlDocument();
                            NameValueCollection nameValueColl = new 
                            NameValueCollection();
                            System.Configuration.ExeConfigurationFileMap map = 
                            new ExeConfigurationFileMap();
                            map.ExeConfigFilename = file;
                            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                            string xml = config.GetSection(sectionName).SectionInformation.GetRawXml();
                            xDoc.LoadXml(xml);
            
                            System.Xml.XmlNode fatherNode = xDoc.ChildNodes[0];
                            System.Xml.XmlNode fathersChildNode = fatherNode.ChildNodes[0];
                            System.Xml.XmlNode ChildrensChildNode_1 = fathersChildNode.ChildNodes[0];
                            System.Xml.XmlAttribute attribute_1_1 = ChildrensChildNode_1.Attributes[0];
                            System.Xml.XmlAttribute attribute_1_2 = ChildrensChildNode_1.Attributes[1];
                            string attribute_1_key = attribute_1_1.Value;
                            string attribute_1_value = attribute_1_2.Value;
                            System.Xml.XmlNode ChildrensChildNode_2 = fathersChildNode.ChildNodes[1];
                            System.Xml.XmlAttribute attribute_2_1 = ChildrensChildNode_2.Attributes[0];
                            System.Xml.XmlAttribute attribute_2_2 = ChildrensChildNode_2.Attributes[1];
                            string attribute_2_key = attribute_2_1.Value;
                            string attribute_2_value = attribute_2_2.Value;
                            Common.Logging.Configuration.NameValueCollection coll = new Common.Logging.Configuration.NameValueCollection();
                            coll.Add(attribute_1_key, attribute_1_value);
                            coll.Add(attribute_2_key, attribute_2_value);
                            Type type = typeof(Log4NetFactoryAdapter);
                            Common.Logging.Configuration.LogSetting set = new Common.Logging.Configuration.LogSetting(type, coll); 
