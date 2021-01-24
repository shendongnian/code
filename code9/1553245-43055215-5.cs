    DataRow dr = tbl.NewRow();
    dr[0] = file;
    for (int cIndex = 1; cIndex + 1 < tbl.Columns.Count; cIndex++)
    {
        dr[cIndex + 1] = cols[cIndex];
        MessageBox.Show(cols[cIndex]);
    }
    tbl.Rows.Add(dr);   // < this one is needed
