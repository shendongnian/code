    wb = xlApp.Workbooks.Open(srcFile,
                               Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                               Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    
    worksheet = (Excel.Worksheet)wb.Worksheets[1];
    object[,] values = worksheet .UsedRange.Value2;
    int rowCount = values.GetLength(0);
    int colCount = values.GetLength(1);
