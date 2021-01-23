    if (xlWorkbook != null && xlWorkbook.Sheets.Count > 0)
    {
             Excel._Worksheet xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
        
             //B8 position an column "IndentValue" in inserted 
             Excel.Range oRng = xlWorksheet.Range["B8"];
             oRng.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftToRight,
             Excel.XlInsertFormatOrigin.xlFormatFromRightOrBelow);
             oRng = xlWorksheet.Range["B8"];
             oRng.Value2 = "IndentValue";
        
             //collect indent value of Col A in Col B
             for (i = 9; i <= xlWorksheet.UsedRange.Rows.Count; i++)
             {
                 Excel.Range aRng = xlWorksheet.Range["A" + i];
                 var Indentvalue = aRng.IndentLevel;
                 xlWorksheet.Cells[i, 2].value = Indentvalue;
              }
             
             Excel.Range xlHeaderRange = xlWorksheet.UsedRange;
        
             object[,] excelObj = (object[,])xlHeaderRange.Value2;
        
             string filename = Path.GetFileNameWithoutExtension(sFile);
        
             if (staticconstList.Contains(filename))
               {
                   if (effectiveDate == DateTime.MinValue)
                    {
                        DateTime.TryParse(Convert.ToString((xlWorksheet.Cells[Definition.DATE_ROW_ID, Definition.DATE_COLUMN_ID] as Excel.Range).Value), out effectiveDate);
                    }
        
                     xlWorkbook.Saved = true;
                     xlWorkbook.Close();
                }
    }
