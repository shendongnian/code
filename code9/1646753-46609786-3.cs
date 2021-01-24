    //Add this method
    
    
      public static HashSet<Tuple<int, string, string, string>>  GetRichTextBoxSections(string[] Lines)
            {
                HashSet<Tuple<int, string, string, string>> Sections = new HashSet<Tuple<int, string, string, string>>();
                int SectionNumber = -1;
                int SectionIndexLineNumber = 0;
                bool FoundNewSectionNumber = false;
                string Col1 = string.Empty;
                string Col2 = string.Empty;
                string Col3 = string.Empty;
                int LinesCount = Lines.Length;
                for (int i = 0; i < LinesCount; i++)
                {
    
                    string NoSpaces = System.Text.RegularExpressions.Regex.Replace(Lines[i], @"\s+", "");
                    if (FoundNewSectionNumber == false)
                    {
                        SectionIndexLineNumber = i;
                    }
    
    
    
                    if (FoundNewSectionNumber)
                    {
                        if (string.IsNullOrWhiteSpace(NoSpaces) || string.IsNullOrEmpty(NoSpaces) & FoundNewSectionNumber == true)
                        {
    
                            Sections.Add(new Tuple<int, string, string, string>(SectionNumber, Col1, Col2, Col3));
                            SectionNumber = -1;
                            FoundNewSectionNumber = false;
                            Col1 = string.Empty;
                            Col2 = string.Empty;
                            Col3 = string.Empty;
                            SectionIndexLineNumber = 0;
                            continue;
    
                        }
                        else
                        {
                            switch (i - SectionIndexLineNumber)
                            {
                                case 1:
                                    Col1 = Lines[i];
                                    break;
                                case 2:
                                    Col2 = Lines[i];
                                    break;
                                default:
                                    Col3 += Lines[i];
                                    break;
                            }
                        }
                    }
                    if (FoundNewSectionNumber == false)
                    {
                        FoundNewSectionNumber = int.TryParse(NoSpaces, out SectionNumber);
                    }
                    if (i == (LinesCount - 1))
                    {
                        Sections.Add(new Tuple<int, string, string, string>(SectionNumber, Col1, Col2, Col3));
                    }
                }
                return Sections;
            }
