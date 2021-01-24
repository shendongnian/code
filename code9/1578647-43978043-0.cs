            public static void Serialize(List<MyClass> myClasses)
            {
                string retval = string.Empty;
                if (myClasses != null)
                {
                    
                    using (StreamWriter sWriter = new StreamWriter("filename", false))
                    {
                        foreach (MyClass myClass in myClasses)
                        {
                            StringBuilder sb = new StringBuilder();
                            using (XmlWriter writer1 = XmlWriter.Create(sb, new XmlWriterSettings() { OmitXmlDeclaration = true }))
                            {
                                XmlSerializer serializer = new XmlSerializer(myClass.GetType());
                                // We are ommitting the namespace to simplifying passing as parameter
                                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                                ns.Add("", "");
                                serializer.Serialize(writer1, myClass);
                            }
                            sWriter.Write(sb.ToString());
                        }
                    }
                }
            }
