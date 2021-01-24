    List<string> bookmarksProcessed = new List<string>();
    foreach (Bookmark b in document.Bookmarks)
    {
        if (!bookmarksProcessed.Contains(b.Name))
        {
            string text = getTextFromBookmarkName(b.Name);
            var newend = b.Range.Start + text.Length;
            var name = b.Name;
            Range rng = b.Range;
            b.Range.Text = text;
            rng.End = newend;
            document.Bookmarks.Add(name, rng);
            bookmarksProcessed.Add(name);
        }
    }
