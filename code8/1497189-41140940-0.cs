    public void ConvertFootNoteToEndNote(Word.Document myDocx, ref string sErrMsg)
            {
                try
                {
                    Word.WdNoteNumberStyle FootNoteNumberStyle;
                    if (!(myDocx.Endnotes.Count > 0 && myDocx.Footnotes.Count > 0))
                    {
                        if (myDocx.Footnotes.Count > 0)
                        {
                            FootNoteNumberStyle = myDocx.Footnotes.NumberStyle;
                            myDocx.Footnotes.Convert();
                            myDocx.Endnotes.NumberStyle = FootNoteNumberStyle;
                        }
                    }
    
                    Word.Range rnFootNoteRange = null;
    
                    if (myDocx.Endnotes.Count > 0)
                    {
                        rnFootNoteRange = myDocx.StoryRanges[Word.WdStoryType.wdEndnotesStory];
    
                        if (rnFootNoteRange.Paragraphs.Count != 0)
                            if (rnFootNoteRange.Paragraphs[1].Range.Text != null)
                                if (rnFootNoteRange.Paragraphs[1].Range.Text.Length < 15)
                                    if (rnFootNoteRange.Paragraphs[1].Range.Text.ToUpper().Contains("NOTE"))
                                        return;
    
                        rnFootNoteRange.Paragraphs.Add(rnFootNoteRange);
                        Word.Paragraph objNewParagraph = rnFootNoteRange.Paragraphs.Add(rnFootNoteRange);
    
                        //if (objNewParagraph != null)
                        //    objNewParagraph.Range.Text = myDocx.Endnotes.Count > 1 ? "Notes" : "Note";
                    }
                }
                catch (Exception ex)
                {
                    sErrMsg = ex.StackTrace;
                    throw;
                }
            }
