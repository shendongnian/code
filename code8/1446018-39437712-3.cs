            using (XmlReader reader = XmlReader.Create(OriginalXml))
            {
                int tab_num = 0;
                bool needs_line = false;
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
                                    needs_line = false;
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
                                    tab_num--;
                                    if (needs_line)
                                    {
                                        writer.Write("\n" + String.Join("", Enumerable.Repeat("\t", tab_num)));
                                    }
                                    writer.Write("</" + reader.Name);
                                    writer.Write(">");
                                    needs_line = true;
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
