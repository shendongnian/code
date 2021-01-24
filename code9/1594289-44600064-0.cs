	public List<WP.BookmarkStart> GetAllBookmarks ()
	{
	    var bmk = _workspace.MainDocumentPart.RootElement.Descendants<WP.BookmarkStart>().ToList();
	    return bmk;
	}
	
