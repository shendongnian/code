    Document doc = new Document(MyDir + @"input.docx");
    
    Section sec = doc.LastSection;
    
    FontChanger changer = new FontChanger();
    sec.Accept(changer);
    
    doc.Save(MyDir + @"17.4.docx");
    /// <summary>
    /// Class inherited from DocumentVisitor, that changes font.
    /// </summary>
    class FontChanger : DocumentVisitor
    {
        /// <summary>
        /// Called when a FieldEnd node is encountered in the document.
        /// </summary>
        public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
        {
            //Simply change font name
            ResetFont(fieldEnd.Font);
            return VisitorAction.Continue;
        }
    
        /// <summary>
        /// Called when a FieldSeparator node is encountered in the document.
        /// </summary>
        public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
        {
            ResetFont(fieldSeparator.Font);
            return VisitorAction.Continue;
        }
    
        /// <summary>
        /// Called when a FieldStart node is encountered in the document.
        /// </summary>
        public override VisitorAction VisitFieldStart(FieldStart fieldStart)
        {
            ResetFont(fieldStart.Font);
            return VisitorAction.Continue;
        }
    
        /// <summary>
        /// Called when a Footnote end is encountered in the document.
        /// </summary>
        public override VisitorAction VisitFootnoteEnd(Footnote footnote)
        {
            ResetFont(footnote.Font);
            return VisitorAction.Continue;
        }
    
        /// <summary>
        /// Called when a FormField node is encountered in the document.
        /// </summary>
        public override VisitorAction VisitFormField(FormField formField)
        {
            ResetFont(formField.Font);
            return VisitorAction.Continue;
        }
    
        /// <summary>
        /// Called when a Paragraph end is encountered in the document.
        /// </summary>
        public override VisitorAction VisitParagraphEnd(Paragraph paragraph)
        {
            ResetFont(paragraph.ParagraphBreakFont);
            return VisitorAction.Continue;
        }
    
        /// <summary>
        /// Called when a Run node is encountered in the document.
        /// </summary>
        public override VisitorAction VisitRun(Run run)
        {
            ResetFont(run.Font);
            return VisitorAction.Continue;
        }
    
        /// <summary>
        /// Called when a SpecialChar is encountered in the document.
        /// </summary>
        public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
        {
            ResetFont(specialChar.Font);
            return VisitorAction.Continue;
        }
    
        private void ResetFont(Aspose.Words.Font font)
        {
            // Add your font changing code here
            font.Name = mNewFontName;
            font.Size = mNewFontSize;
        }
    
        private double mNewFontSize = 18;
        private string mNewFontName = "Times New Roman";
    }
