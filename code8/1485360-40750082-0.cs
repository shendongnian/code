    Microsoft.Office.Interop.Excel.Range range = excelSheet.UsedRange;
    for (int index = 0; index < range.Rows.Count; index++)
    {
        string cellValue = excelSheet.Cells[index, 16].Value.ToString();
        //Do some processing.
        excelSheet.Cells[index, 16] = cellValue; 
    }
