	File.Copy(sCurrentPath + "\\" + "testTemplate.DOC", sCurrentPath + "\\" + "test.DOC");
	Application app = new Application();
	Document doc = app.Documents.Add(sCurrentPath + "\\" + "test.DOC");
	foreach (string sValue in myList)
	{
	    var List = doc.Paragraphs[17];
	    myList = doc.Paragraphs.Add(myList.Range);
	    myList.Range.Text = sValue;
	}
	if (doc.Bookmarks.Exists("Date"))
	{
	    object oBookMark = "Date";
	    doc.Bookmarks.get_Item(ref oBookMark).Range.Text = DateTime.Now.ToString("MM/dd/yyyy");
	}
	if (doc.Bookmarks.Exists("Signature"))
	{
	    object oBookMark = "Signature";
	    doc.Bookmarks.get_Item(ref oBookMark).Range.Text = "My Name";
	}
	if (doc.Bookmarks.Exists("Title"))
	{
	    object oBookMark = "Title";
	    doc.Bookmarks.get_Item(ref oBookMark).Range.Text = "Title Here";
	}
	doc.ExportAsFixedFormat(sCurrentPath + "\\" + "test.pdf", WdExportFormat.wdExportFormatPDF);
	File.Delete(sCurrentPath + "\\" + "testCopy.DOC");
	File.Delete(sCurrentPath + "\\" + "test.pdf");
	((_Document)doc).Close();
	((_Application)app).Quit();
