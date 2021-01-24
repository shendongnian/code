    //setup
    using (var wordDoc = WordprocessingDocument.Open(@"C:\test\cb\exptable.docx", true))
    {
        MainDocumentPart mainPart = wordDoc.MainDocumentPart;
        var document = mainPart.Document;
        var bookmarks = document.Body.Descendants<BookmarkStart>();
    
        //find bookmark
        var myBookmark = bookmarks.First(bms => bms.Name == "table");
        //dig through parent until we hit a table
        var digForTable = myBookmark.Parent;
        while(!(digForTable is Table))
        {
            digForTable = digForTable.Parent;
        }
        //get rows
        var rows = digForTable.Descendants<TableRow>().ToList();
        //remember you have a header, so keep row 1, clone row 2 (our template for dynamic entry)
        var myRow = (TableRow)rows.Last().Clone();
        //remove it after cloning.
        rows.Last().Remove();
        //do stuf with your row and insert it in the table
        for (int i = 0; i < 10; i++)
        {
            //clone our "reference row"
            var rowToInsert = (TableRow)myRow.Clone();
            //get list of cells
            var listOfCellsInRow = rowToInsert.Descendants<TableCell>().ToList();
            //just replace every bit of text in cells with row-number for this example
            foreach(TableCell cell in listOfCellsInRow)
            {
    			cell.Descendants<Text>().FirstOrDefault().Text = i.ToString();
            }
            //add new row to table, after last row in table
            digForTable.Descendants<TableRow>().Last().InsertAfterSelf(rowToInsert);
        }
    }
