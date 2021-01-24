    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        //span the first cell 3 columns
        e.Row.Cells[0].ColumnSpan = 3;
        //remove the next cell twice
        e.Row.Cells.RemoveAt(1);
        e.Row.Cells.RemoveAt(1);
    }
