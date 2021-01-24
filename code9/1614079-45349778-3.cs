    public static void ReplaceBookmarkContentWithFile(this Microsoft.Office.Interop.Word.Document document, string path, Microsoft.Office.Interop.Word.Range range, string bookmarkName)
    {
        var startRange = document.Range(range.Start, range.End + 1);
        object missing = System.Reflection.Missing.Value;
        object ConfirmConversions = false;
        object Link = false;
        object Attachment = false;
        range.InsertFile(path, ref missing, ref ConfirmConversions, ref Link, ref Attachment);
        object newRange = document.Range(startRange.Start, startRange.End - 1);
        document.Bookmarks.Add(bookmarkName, ref newRange);
    }
