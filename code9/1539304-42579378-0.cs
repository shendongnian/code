    private static void InsertHtml(Word.Range range, string html)
    {
        File.WriteAllText("temp.html", html);
        range.InsertFile(Path.GetFullPath("temp.html"), Type.Missing, false);
        //this is the interesting part
        if (range.Find.Execute("TEMPTEXT")) {
            //range now points to only the text TEMPTEXT
            //We make sure to take the entire paragraph
            var paragraph = range.Paragraphs[1];
            //Then we remove the entire paragraph range
            var paragraphRange = paragraph.Range;
            paragraphRange.Delete();
        }
    }
