    public void Meth()
    	{
    		var bookmarks = SimpleBookmark.GetBookmark(reader);
    		for (int i = 0; i < bookmarks.Count; i++)
    		{
    			string zoomValue = "1.25";
    
    			if (bookmarks[i]["Title"].ToString() == "Cover" ||
    				bookmarks[i]["Title"].ToString() == "C")
    			{
    				zoomValue = "1";
    			}
    
    			int pageNumber = Int32.Parse(bookmarks[i]["Page"].ToString().Split(' ')[0]);
    			// increase pageHight by one to have a nicer zoom
    			float pageHeight = reader.GetPageSize(pageNumber).Height + 1;
    
    			string replaceValue = $"{pageNumber} XYZ 0 {pageHeight} {zoomValue}";
    
    			ChangeZoom(bookmarks[i], replaceValue);
    		}
    	}
    	private static void ChangeZoom(Dictionary<string, object> bookmark, string replaceValue)
    	{
    		bookmark["Page"] = replaceValue;
    		if (bookmark.ContainsKey("Kids"))
    		{
    			(bookmark["Kids"] as List<Dictionary<string, object>>).ForEach(bm=>ChangeZoom(bm, replaceValue));
    		}
    	}
