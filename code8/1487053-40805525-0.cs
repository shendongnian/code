    int columnCellIndex = 2;
    foreach (var captionGroupInfo in extraCaptionGroupings)
    {
      Microsoft.Office.Interop.Excel.Range currRange = newWorksheet.Range[newWorksheet.Cells[1, columnCellIndex], 
                                                                          newWorksheet.Cells[1, columnCellIndex + captionGroupInfo.Item2 - 1]];
      currRange.Value2 = captionGroupInfo.Item1;
      currRange.Select();
      currRange.Merge(Missing.Value);
      columnCellIndex += captionGroupInfo.Item2;
    }
