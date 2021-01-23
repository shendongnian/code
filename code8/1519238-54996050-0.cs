       TableCellProperties tableCellProperties1 = VARIABLE.GetFirstChild<TableCellProperties>();
       TableCellWidth tableCellWidth1 = tableCellProperties1.GetFirstChild<TableCellWidth>();
       int _width = Int32.Parse(tableCellWidth1.Width);
       TableRowProperties tableRowProperties1 = 
       VARIABLE.Parent.GetFirstChild<TableRowProperties>();
       TableRowHeight tableRowHeight1 = 
       tableRowProperties1.GetFirstChild<TableRowHeight>();
       int _height = Int32.Parse(tableRowHeight1.Val);     
       document.MainDocumentPart.Document.Save();
