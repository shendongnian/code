     xl.Range first_range = MySheet.Cells.SpecialCells(xl.XlCellType.xlCellTypeLastCell, Type.Missing);
            xl.Range usedRange = MySheet.get_Range("Q2", first_range);
            xl.Range rows = usedRange.Rows;
     int count = 0;
            foreach (xl.Range row in rows)
            {
                if (count > 0)
                {
                    xl.Range firstcell = row.Cells[1];    
                    string firstCellValue = firstcell.Value as string;    
                    if (string.IsNullOrEmpty(firstCellValue))
                    {
                        row.EntireRow.Interior.Color = System.Drawing.Color.Red;
                    }
                }
                count++;
            }
