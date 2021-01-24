    private static void ChangeValue(Worksheet oWorksheet)
    {
        var colNo = oWorksheet.UsedRange.Columns.Count;
        var rowNo = oWorksheet.UsedRange.Rows.Count;
        for (var j = 1; j <= colNo; j++)
        {
            for (var i = 1; i <= rowNo; i++)
            {
                Range row = oWorksheet.Rows.Cells[i, j];
                if (row.Value.ToString().Contains("*"))
                {
                    row.Value = row.Value.ToString().Replace("*","_");
                }
            }
        }
    }
