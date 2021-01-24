            PowerPoint.SectionProperties oSections = oPresentation.SectionProperties;
                if(oSections.Count > 0)
                {
                    for (int iSection = oSections.Count; iSection > 0; iSection--)
                    {
                        oSections.Delete(iSection, false);
                    }
                }
