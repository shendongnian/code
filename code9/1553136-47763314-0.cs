    using (MemoryStream ms = new MemoryStream())
    {
	    HtmlToPdfResult pdfResult = HtmlToPdf.ConvertHtml(htmlString, ms);
	    HtmlElement element = pdfResult.HtmlDocument.GetElementById(elementId);
		string bookmarkName = "Your bookmark name";
	    PdfBookmark bookmark = element.CreateBookmark(bookmarkName);
	    bookmark.Destination = element.Location.CreateDestination();
	    pdfResult.PdfDocument.Bookmarks.Add(bookmark);
	    pdfResult.PdfDocument.Save(ms);
    }
