    Document doc = new Document();
    PdfCopy copy = new PdfCopy(doc, stream);                
    doc.Open();
    for (int x = 0, y = pages; x < y; x++)
    {
	    PdfImportedPage import = copy.GetImportedPage(pdf, x + 1);
	    PageStamp stamp = copy.CreatePageStamp(import);
	    Rectangle rect = stamp.GetUnderContent().PdfWriter.PageSize;
	    ColumnText.ShowTextAligned(stamp.GetUnderContent(),
		    Element.ALIGN_CENTER, new Phrase(User.Identity.Name, font),
			    (rect.Bottom + rect.Top) / 2, rect.Bottom + 8, 0);
	    stamp.AlterContents();
	    copy.AddPage(import);
    }
