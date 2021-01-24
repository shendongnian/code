                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                    rows.MoveNext();
                    IRow r = (HSSFRow)rows.Current;
                    int z = r.LastCellNum - 1;
                    DataTable dt = new DataTable();
                    for (int j = 0; j < z; j++)
                    {
                        ICell cell = r.GetCell(j);
                        dt.Columns.Add(cell.StringCellValue);                    
                    }
                    rows.Reset();
                    while (rows.MoveNext())
                    {
                    //... get the rest of the data....
