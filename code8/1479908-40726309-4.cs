    enum RowOrCol { Row, Column };
    private static void ConventionalRemoveEmptyRowsCols(Excel.Worksheet worksheet)
    {
      Excel.Range usedRange = worksheet.UsedRange;
      int totalRows = usedRange.Rows.Count;
      int totalCols = usedRange.Columns.Count;
      RemoveEmpty(usedRange, RowOrCol.Row);
      RemoveEmpty(usedRange, RowOrCol.Column);
    }
    private static void RemoveEmpty(Excel.Range usedRange, RowOrCol rowOrCol)
    {
      int count;
      Excel.Range curRange;
      if (rowOrCol == RowOrCol.Column)
        count = usedRange.Columns.Count;
      else
        count = usedRange.Rows.Count;
      for (int i = count; i > 0; i--)
      {
        bool isEmpty = true;
        if (rowOrCol == RowOrCol.Column)
          curRange = usedRange.Columns[i];
        else
          curRange = usedRange.Rows[i];
        foreach (Excel.Range cell in curRange.Cells)
        {
          if (cell.Value != null)
          {
            isEmpty = false;
            break; // we can exit this loop since the range is not empty
          }
          else
          {
            // Cell value is null contiue checking
          }
        } // end loop thru each cell in this range (row or column)
        if (isEmpty)
        {
          curRange.Delete();
        }
      }
    }
