        public void PrependFooter(string footerTemplatePath, string documentPath)
        {
            // Open docx where append footer
            using (var wdDoc = WordprocessingDocument.Open(documentPath, true))
            {
                var mainPart = wdDoc.MainDocumentPart;
                // Remove exist footer
                mainPart.DeleteParts(mainPart.FooterParts);
                // Create new footer
                var footerParts = mainPart.AddNewPart<FooterPart>();
                // Get Id of new footer
                var rId = mainPart.GetIdOfPart(footerParts);
                // Open the footer document to be copied
                using (var wdDocSource = WordprocessingDocument.Open(footerTemplatePath, true))
                {
                    var firstFooter = wdDocSource.MainDocumentPart.FooterParts.LastOrDefault();
                    if (firstFooter != null)
                    {
                        // Copy content of footer
                        footerParts.FeedData(firstFooter.GetStream());
                        // Keep formatting
                        foreach (var childElement in footerParts.Footer.Descendants<Paragraph>())
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
                        // Create list of Parts ID needed to new footer
                        var listToAdd = new List<KeyValuePair<Type, Stream>>();
                        foreach (var idPart in firstFooter.Parts)
                        {
                            var part = firstFooter.GetPartById(idPart.RelationshipId);
                            if (part is ImagePart)
                            {
                                footerParts.AddNewPart<ImagePart>("image/png", idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (ImagePart), part.GetStream()));
                            }
                            else if (part is DiagramStylePart)
                            {
                                footerParts.AddNewPart<DiagramStylePart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramStylePart), part.GetStream()));
                            }
                            else if (part is DiagramColorsPart)
                            {
                                footerParts.AddNewPart<DiagramColorsPart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramColorsPart),
                                    part.GetStream()));
                            }
                            else if (part is DiagramDataPart)
                            {
                                footerParts.AddNewPart<DiagramDataPart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramDataPart), part.GetStream()));
                            }
                            else if (part is DiagramLayoutDefinitionPart)
                            {
                                footerParts.AddNewPart<DiagramStylePart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramStylePart), part.GetStream()));
                            }
                            else if (part is DiagramPersistLayoutPart)
                            {
                                footerParts.AddNewPart<DiagramPersistLayoutPart>(idPart.RelationshipId);
                                listToAdd.Add(new KeyValuePair<Type, Stream>(typeof (DiagramPersistLayoutPart),
                                    part.GetStream()));
                            }
                        }
                        // Foreach ID, copy stream to new footer
                        var i = 0;
                        foreach (var idPart in footerParts.Parts)
                        {
                            var part = footerParts.GetPartById(idPart.RelationshipId);
                            if (part.GetType() == listToAdd[i].Key)
                            {
                                part.FeedData(listToAdd[i].Value);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        mainPart.DeleteParts(mainPart.FooterParts);
                        var sectToRemovePrs = mainPart.Document.Body.Descendants<SectionProperties>();
                        foreach (var sectPr in sectToRemovePrs)
                        {
                            // Delete reference of footer
                            sectPr.RemoveAllChildren<FooterReference>();
                        }
                        return;
                    }
                }
                // Get all sections, and past footer to each section (Page)
                var sectPrs = mainPart.Document.Body.Descendants<SectionProperties>();
                foreach (var sectPr in sectPrs)
                {
                    // Delete old reference
                    sectPr.RemoveAllChildren<FooterReference>();
                    // Add new footer reference
                    sectPr.PrependChild(new FooterReference { Id = rId });
                }
            }
        }
