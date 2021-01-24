    public static void WordHighliter(Word.Document doc, IEnumerable<string> phrases, Word.WdColorIndex color)
                {
                Word.Range rng = doc.Content;
                foreach (string phrase in phrases)
                    {
                    rng = doc.Content;
                    Word.Find find = rng.Find;
    
                    find.ClearFormatting();
                    find.Text = phrase;
                    find.Forward = true;
                    find.Wrap = Word.WdFindWrap.wdFindStop;
                    find.Format = false;
                    find.MatchCase = false;
                    find.MatchWholeWord = true;
                    find.MatchWildcards = false;
                    find.MatchSoundsLike = false;
                    find.MatchAllWordForms = false;
                    find.MatchByte = true;
    
                    while (find.Execute())
                        {
                        Int32 start = rng.Start;
                        // ensure that phrase does not start within another word
                        if (rng.Start == rng.Words[1].Start)
                            {
                            rng.HighlightColorIndex = Word.WdColorIndex.wdYellow;
                            }
                        }
                    }
    
                }
