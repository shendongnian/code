    var colNo = oWorksheet.UsedRange.Columns.Count;
    var rowNo = oWorksheet.UsedRange.Rows.Count;
    object[,] array = oWorksheet.UsedRange.Value;
    for (var j = 1; j <= colNo; j++)
    {
        for (var i = 1; i <= rowNo; i++)
        {
            if (array[i,j].ToString().Contains("*"))
            {
                array[i, j] = array[i, j].ToString().Replace("*","_");
            }
        }
    }
