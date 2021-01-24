    for (int i = 0; i < gvDb.RowCount - 1; i++)
    {
        var row = gvDb.Rows[i];
        if (string.IsNullOrEmpty(Convert.ToString(row.Cells[1].Value)))
        {
            row.Visible = false;
        }
    }
