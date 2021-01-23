    public static class ExtensionClass
    {
    //A method for copying a row and insert it:
    //Copy an existing row and insert it
    //We don't need to copy styles of a refRow because a CloneNode() or Clone() methods do it for us
    public static Row CopyToLine(this Row refRow, uint rowIndex, SheetData sheetData)
    {
        uint newRowIndex;
        var newRow = (Row)refRow.CloneNode(true);        
        // Loop through all the rows in the worksheet with higher row 
        // index values than the one you just added. For each one,
        // increment the existing row index.
        IEnumerable<Row> rows = sheetData.Descendants<Row>().Where(r => r.RowIndex.Value >= rowIndex);
        foreach (Row row in rows)
        {
            newRowIndex = System.Convert.ToUInt32(row.RowIndex.Value + 1);
            foreach (Cell cell in row.Elements<Cell>())
            {
                // Update the references for reserved cells.
               string cellReference = cell.CellReference.Value;
               cell.CellReference = new StringValue(cellReference.Replace(row.RowIndex.Value.ToString(), newRowIndex.ToString()));
               cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
            }
            // Update the row index.
            row.RowIndex = new UInt32Value(newRowIndex);
        }         
        sheetData.InsertBefore(newRow, refRow);
        return newRow;
       }
    }
