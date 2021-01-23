    for(int n = 1; n <= excelSheet.Columns.Count; n++)
    {
        string cellValue = excelSheet.Cells[n, 16].Value.ToString();
        //Do some processing.
        excelSheet.Cells[n, 16] = cellValue; 
    }
