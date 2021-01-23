            using (XmlReader reader = XmlReader.Create(OriginalXml))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(FilteredXml, ws))
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
                                    writer.WriteStartElement(reader.Name);
                                    while (reader.MoveToNextAttribute())
                                        writer.WriteAttributeString(reader.Name, reader.Value);
                                }
                                
                                break;
                            case XmlNodeType.Text:
                                if (skip == 0)
                                {
                                    writer.WriteString(reader.Value);
                                }
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                if (skip == 0)
                                {
                                    writer.WriteProcessingInstruction(reader.Name, reader.Value);
                                }   
                                break;
                            case XmlNodeType.Comment:
                                if (skip == 0)
                                {
                                    writer.WriteComment(reader.Value);
                                }
                                break;
                            case XmlNodeType.EndElement:
                                if (skip == 0)
                                {
                                    writer.WriteFullEndElement();
                                }
                                skip -= reader.Name.Equals(RemoveMe) ? 1 : 0;
                                if (skip < 0)
                                {
                                    throw new Exception("wrong sequence");
                                }
                                break;
                        }
                    }
                }
            }
