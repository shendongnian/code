    for (var i = 0; i < tbl.Columns.Count; i++)
    {
        //If you're at the first column 
        if (i == 0)
        {
            row[i] = colorTable[rowNum];
        }
        else
        {
            row[i] = currentRow[rowNum, i + 1].Text;
        }
    }
