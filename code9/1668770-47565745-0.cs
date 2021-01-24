    string filePath = Application.StartupPath + @"\docs\test.docx";
    Word.Application wordApp = new Word.Application();
    Word.Document wordDoc = wordApp.Documents.Open(filePath);
    object oMissing = System.Reflection.Missing.Value;
    wordApp.Visible = true;
    Word.Selection selection = wordApp.Selection;
    //copy and keep template table
    var tableToUse = wordDoc.Tables[1];
    //copy the empty table in the clipboard
    Word.Range range = tableToUse.Range;
    range.Copy();
    //fill the original table
    Word.Cell cell;
    cell = wordDoc.Tables[1].Cell(2, 1);
    cell.Range.Text = "First Column...";
    cell = wordDoc.Tables[1].Cell(2, 2);
    cell.Range.Text = "Second Column...";
    cell = wordDoc.Tables[1].Cell(2, 3);
    cell.Range.Text = "Third Column...";
    //inserting a page break: first go to end of document
    selection.EndKey(Word.WdUnits.wdStory, Word.WdMovementType.wdMove);
    //insert a page break
    object breakType = Word.WdBreakType.wdPageBreak;
    selection.InsertBreak(ref breakType);
    //paste the template table in new page
    //add a new table (initially with 1 row and one column) at the end of the document
    Word.Table tableCopy = wordDoc.Tables.Add(selection.Range, 1, 1, ref oMissing, ref oMissing);
    //paste the original template table over the new one
    tableCopy.Range.Paste();
