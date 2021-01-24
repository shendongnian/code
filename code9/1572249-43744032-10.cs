                case XmlNodeType.Comment:
                    if (writePropertyName)
                    {
                        writer.WriteComment(node.Value);
                    }
                    break;
