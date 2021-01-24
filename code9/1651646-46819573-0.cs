    var rowCount = xlRange.Rows.Count;
    var colCount = xlRange.Columns.Count;
    for (int row = 1; row <= rowCount; ++row) {
        Console.WriteLine();
        for (int col = 1; col <= colCount; ++col) {
            //write the value to the console if cell value ends on 'd'
            if (xlRange.Cells[row, col]?.Value2?.ToString().EndsWith("d") ?? false)
                Console.Write(xlRange.Cells[row, col].Value2.ToString() + "\t");
        }
    }
