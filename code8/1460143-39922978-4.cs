    void ReverseDTRows(DataTable dt)
    {
        string sortCol = "__sort__";
        if (!dt.Columns.Contains(sortCol) )
            dt.Columns.Add(sortCol, typeof(int));
        for (int i = 0; i < dt.Rows.Count; i++)
            dt.Rows[i].SetField<int>(sortCol, dt.Rows.Count - i);
        DataView dv = dt.DefaultView;
        dv.Sort = sortCol + " ASC";
        dt = dv.ToTable();
        dt.Columns.Remove(sortCol);
    } 
