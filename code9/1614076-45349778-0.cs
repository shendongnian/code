    var bmRange = bookmark.Range;
    string bookmarkName = bookmark.Name;
    
    // plus 1 on the end prevents startRange to collapse on insert.
    // be shure there is something after the end
    var startRange = document.Range(bmRange.Start, bmRange.End + 1);
    object missing = System.Reflection.Missing.Value;
    object ConfirmConversions = false;
    object Link = false;
    object Attachment = false;
    bmRange.InsertFile(psFile, ref missing, ref ConfirmConversions, ref Link, ref Attachment);
    // after insert the startRange contains the inserted content + 1
    var newRange = document.Range(startRange.Start, startRange.End - 1);
    document.Bookmarks.Add(bookmarkName, ref newRange);
