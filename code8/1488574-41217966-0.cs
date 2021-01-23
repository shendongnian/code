    public static void ReadAndStrikeBulletsWithOpenXml()
            {
                var sourcePath = @"C:\temp\test.docx";
                var destinationPath = @"C:\temp\new-test.docx";
                File.Copy(sourcePath, destinationPath);
                using (var document = WordprocessingDocument.Open(destinationPath, true))
                {
                    Numbering numbering = document.MainDocumentPart.NumberingDefinitionsPart.Numbering;
                    var abstractNum = numbering.ChildElements.FirstOrDefault(x => x.LocalName.Equals("abstractNum"));
                    if (abstractNum?.ChildElements != null)
                    {
                        foreach (var child in abstractNum.ChildElements)
                        {
                            if (child.OuterXml.Contains("<w:lvl"))
                            {
                                XmlDocument levelXml = new XmlDocument();
                                levelXml.LoadXml(child.OuterXml);
    
                                XmlNamespaceManager namespaceManager = new XmlNamespaceManager(levelXml.NameTable);
                                namespaceManager.AddNamespace("w",
                                    "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    
                                XmlNode runProperty = levelXml.SelectSingleNode("w:lvl/w:rPr", namespaceManager);
                                if (runProperty == null)
                                {
                                    // Need to uncomment this if you prefer to strike all bullets at all levels
                                    //child.InnerXml = child.InnerXml +
                                    //                 "<w:rPr><w:strike w:val\"1\"/></w:rPr>";
                                }
                                else if (runProperty.InnerXml.Contains("w:strike"))
                                {
                                    XmlDocument runXml = new XmlDocument();
                                    runXml.LoadXml(runProperty.OuterXml);
    
                                    XmlNamespaceManager runNamespaceManager = new XmlNamespaceManager(runXml.NameTable);
                                    runNamespaceManager.AddNamespace("w",
                                        "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    
                                    XmlNode strikeNode = runXml.SelectSingleNode("w:rPr/w:strike", namespaceManager);
                                    if (strikeNode?.Attributes != null)
                                    {
                                        if (strikeNode.Attributes["w:val"] == null)
                                        {
                                            // do nothing
                                        }
                                        else if (strikeNode.Attributes["w:val"].Value == "0")
                                        {
                                            child.InnerXml = child.InnerXml.Replace("w:strike w:val=\"0\"", "w:strike w:val=\"1\"");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    document.MainDocumentPart.Document.Save();
                    document.Close();
                }
            }
