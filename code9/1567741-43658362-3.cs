    public void Meth()
    	{
    		var bookmarks = SimpleBookmark.GetBookmark(reader);
    		foreach (var prntBookmark in bookmarks)
			{
				string zoomValue = "1.25";
				if (prntBookmark["Title"].ToString() == "Cover" ||
					prntBookmark["Title"].ToString() == "C")
				{
					zoomValue = "1";
				}
				int pageNumber = Int32.Parse(prntBookmark["Page"].ToString().Split(' ')[0]);
				// increase pageHight by one to have a nicer zoom
				float pageHeight = reader.GetPageSize(pageNumber).Height + 1;
				ChangeZoom(prntBookmark, $"{pageNumber} XYZ 0 {pageHeight} {zoomValue}");
			}
    	}
    	private static void ChangeZoom(Dictionary<string, object> bookmark, string replaceValue)
    	{
    		bookmark["Page"] = replaceValue;
    		if (bookmark.ContainsKey("Kids"))
    		{
    			(bookmark["Kids"] as List<Dictionary<string, object>>)?.ForEach(bm=>ChangeZoom(bm, replaceValue));
    		}
    	}
