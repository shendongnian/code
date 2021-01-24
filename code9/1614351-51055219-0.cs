    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
    Document doc = app.Documents.Open(Path.Combine(Environment.CurrentDirectory, "Report.doc"));
    Dictionary<string, string> bookmarks = new Dictionary<string, string> { { "DateOfIssue", "23-06-2018"}, { "TotalNumOfPages", "20" } };
    foreach (var bookmark in bookmarks)
    {
        Bookmark bm = doc.Bookmarks[bookmark.Key];
        Range range = bm.Range;
        range.Text = bookmark.Value;
        doc.Bookmarks.Add(bookmark.Key, range);
    }
