    using (var templateFile = System.IO.File.Open(Server.MapPath("~/OurCompanyTeam.pptx"), FileMode.Open, FileAccess.Read))
    {
        using (var stream = new MemoryStream())
                {
                    templateFile.CopyTo(stream);
                    using (var presentationDocument = PresentationDocument.Open(stream, true))
                    {
                        var presentationPart = presentationDocument.PresentationPart;
                        var presentation = presentationPart.Presentation;
                        var slideList = new List<SlidePart>();
                        foreach (SlideId slideID in presentation.SlideIdList)
                        {
                            var slidePart = (SlidePart)presentationPart.GetPartById(slideID.RelationshipId);
                            AlternateContent alternateContent1 = slidePart.Slide.GetFirstChild<AlternateContent>();
                            if (alternateContent1 != null)
                            {
                                slidePart.Slide.RemoveAllChildren<AlternateContent>();
                            }
                                var trns1 = new Transition();
                                trns1.Duration = "2000";
                                trns1.AdvanceOnClick = false;
                                trns1.AdvanceAfterTime = "2000"; //ITEM #2
                                trns1.Speed = TransitionSpeedValues.Slow;
                                var alternateContent = new AlternateContent();
                                alternateContent.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
                                AlternateContentChoice alternateContentChoice = new AlternateContentChoice() { Requires = "p14" };
                                alternateContentChoice.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");
                                alternateContentChoice.Append(trns1);
                                alternateContent.Append(alternateContentChoice);
                                slidePart.Slide.Append(alternateContent);
                        }
                        var presentationPropertiesPart = presentationPart.PresentationPropertiesPart;
                        var presentationProperties = presentationPropertiesPart.PresentationProperties;
                        presentationProperties.RemoveAllChildren<ShowProperties>();
                        presentationProperties.Append(NewShowProperties());
                        presentationDocument.ChangeDocumentType(PresentationDocumentType.Slideshow);  //ITEM #3
                    }
                    byte[] buffer = stream.ToArray();
                    MemoryStream ms = new MemoryStream(buffer);
                    FileStream file = new FileStream(System.IO.Path.GetDirectoryName(_sourceFile) + "/NewSlideShow.ppsx",
                        FileMode.Create, FileAccess.Write);  //ITEM #4
                    ms.WriteTo(file);
                    file.Close();
                }   
    }
