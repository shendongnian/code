    var table = pptSlide.Shapes.AddTable();
    destRange = targetSheet.get_Range("A1:B15");
    for (int i = 1; i <= destRange.Rows; i++) 
    { 
        for (int j = 1; j <= destRange.Columns; j++) 
        {
            table.Table.Cell(i, j).Shape.TextFrame.TextRange.Text =destRange[i, j].Text;
        } 
    } 
