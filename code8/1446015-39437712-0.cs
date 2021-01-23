            using (XmlReader reader = XmlReader.Create(PathNew))
            {
                int step = 0;
                using (StreamWriter writer = new StreamWriter(PathFiltered, false))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                skip += reader.Name.Equals(RemoveMe) ? 1 : 0;
                                if (skip == 0)
                                {
                                    writer.Write("<" + reader.Name);
                                    writer.Write(">");
                                }
                                break;
                            case XmlNodeType.Text:
                                if (skip == 0)
                                {
                                    writer.Write(reader.Value);
                                }
                                break;
                            case XmlNodeType.EndElement:
                                if (skip == 0)
                                {
                                    writer.Write("</" + reader.Name);
                                    writer.Write(">");
                                }
                                skip -= reader.Name.Equals(RemoveMe) ? 1 : 0;
                                if (skip <0 )
                                {
                                    writer.Flush();
                                    writer.Close();
                                    throw new Exception("wrong sequqnce");
                                }
                                break;
                        }
                        writer.Flush();
                    }
                    writer.Close();
                }
            }
