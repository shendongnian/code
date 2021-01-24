    for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
    {
        string cellText = GridView1.HeaderRow.Cells[i].Text;
    
        //check if the column name exists and if so make it unique
        if (dt.Columns.Contains(cellText))
        {
            dt.Columns.Add(cellText + "_" + i);
        }
        else
        {
            dt.Columns.Add(cellText);
        }
    }
