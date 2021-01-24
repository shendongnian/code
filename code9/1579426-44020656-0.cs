    I did something like this and it working fine for me.
    foreach (Cell cell in row.Descendants<Cell>())
                                {
                                    if (cell.CellValue != null)
                                    {
      var NumberOfCol = datatable.Columns.Count;
      DataRow tempRow = datatable.NewRow();
                                            for (int k = 0; k < NumberOfCol; k++)
                                            {
                                                if (tempRow[k] != null)
                                                {
                                                    tempRow[k] = row.Count() > k ? GetValue(spreadsheet, row.Descendants<Cell>().ElementAt(k)) : "";
                                                }
                                                else
                                                {
                                                    tempRow[k] = "";
                                                }}
