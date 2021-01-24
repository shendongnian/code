    for (var row = 1; row <= excelRange.Rows.Count; row++)
    {
        for (var column = 1; row <= excelRange.Columns.Count; row++)
        {
            var cellText = excelRange[row, column].Text.ToString();
        }
    }
