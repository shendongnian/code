        public void PrependHeader(string headerTemplatePath, string documentPath)
        {
            // Open docx where we need to add header
            using (var wdDoc = WordprocessingDocument.Open(documentPath, true))
            {
                var mainPart = wdDoc.MainDocumentPart;
                // Delete exist header
                mainPart.DeleteParts(mainPart.HeaderParts);
                // Create new header
                var headerPart = mainPart.AddNewPart<HeaderPart>();
                // Get id of new header
                var rId = mainPart.GetIdOfPart(headerPart);
                // Open the header document to be copied
                using (var wdDocSource = WordprocessingDocument.Open(headerTemplatePath, true))
                {
                    // Get header part
                    var firstHeader = wdDocSource.MainDocumentPart.HeaderParts.FirstOrDefault();
                    if (firstHeader != null)
                    {
                        // Copy content of header to new header
                        headerPart.FeedData(firstHeader.GetStream());
                        // Keep formatting
                        foreach (var childElement in headerPart.Header.Descendants<Paragraph>())
                        {
                            var paragraph = (Paragraph) childElement;
                            if (paragraph.ParagraphProperties.SpacingBetweenLines == null)
                            {
                                paragraph.ParagraphProperties.SpacingBetweenLines = new SpacingBetweenLines
                                {
                                    After = "0"
                                };
                                paragraph.ParagraphProperties.ParagraphStyleId = new ParagraphStyleId
                                {
                                    Val = "No Spacing"
                                };
                            }
                        }
                        // Get all ids of every 'Parts'
                        var listToAdd = new List<KeyValuePair<Type, Stream>>();
                        foreach (var idPart in firstHeader.Parts)
                        {
                            var part = firstHeader.GetPartById(idPart.RelationshipId);
                            if (part is ImagePart)
                            {
                                headerPart.AddNewPart<ImagePart>("image/png", idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (ImagePart), part.GetStream()));
                            }
                            else if (part is DiagramStylePart)
                            {
                                headerPart.AddNewPart<DiagramStylePart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramStylePart), part.GetStream()));
                            }
                            else if (part is DiagramColorsPart)
                            {
                                headerPart.AddNewPart<DiagramColorsPart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramColorsPart),
                                    part.GetStream()));
                            }
                            else if (part is DiagramDataPart)
                            {
                                headerPart.AddNewPart<DiagramDataPart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramDataPart), part.GetStream()));
                            }
                            else if (part is DiagramLayoutDefinitionPart)
                            {
                                headerPart.AddNewPart<DiagramStylePart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramStylePart), part.GetStream()));
                            }
                            else if (part is DiagramPersistLayoutPart)
                            {
                                headerPart.AddNewPart<DiagramPersistLayoutPart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramPersistLayoutPart),
                                    part.GetStream()));
                            }
                        }
                        // Foreach Part, copy stream to new header
                        var i = 0;
                        foreach (var idPart in headerPart.Parts)
                        {
                            var part = headerPart.GetPartById(idPart.RelationshipId);
                            if (part.GetType() == listToAdd[i].Key)
                            {
                                part.FeedData(listToAdd[i].Value);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        mainPart.DeleteParts(mainPart.HeaderParts);
                        var sectToRemovePrs = mainPart.Document.Body.Descendants<SectionProperties>();
                        foreach (var sectPr in sectToRemovePrs)
                        {
                            // Delete reference of old header
                            sectPr.RemoveAllChildren<HeaderReference>();
                        }
                        return;
                    }
                }
                // Get all sections, and past header to each section (Page)
                var sectPrs = mainPart.Document.Body.Descendants<SectionProperties>();
                foreach (var sectPr in sectPrs)
                {
                    // Remove old header reference 
                    sectPr.RemoveAllChildren<HeaderReference>();
                    // Add new header reference
                    sectPr.PrependChild(new HeaderReference { Id = rId });
                }
            }
        }
