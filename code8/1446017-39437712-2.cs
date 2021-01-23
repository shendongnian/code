            using (XmlReader reader = XmlReader.Create(OriginalXml))
            {
                int tab_num = 0;
                using (StreamWriter writer = new StreamWriter(FilteredXml, false))
                {
                    int skip = 0;
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                skip += reader.Name.Equals(RemoveMe) ? 1 : 0;
                                if (skip == 0)
                                {
                                    writer.Write("\n" + String.Join("", Enumerable.Repeat("\t", tab_num)));
                                    tab_num++;
                                    writer.Write("<" + reader.Name);
                                    while (reader.MoveToNextAttribute())
                                        writer.Write(" " + reader.Name + "='" + reader.Value + "'");
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
                                    writer.Write(">\n");
                                    tab_num--;
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
