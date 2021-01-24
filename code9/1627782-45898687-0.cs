    DbAdapter.Fill(dt);
    for (int i = dt.Columns.Count - 1; i >= 0; i--)
    {
        if (dt.AsEnumerable().All(row => row[i].ToString() == ""))
        {
            dt.Columns.RemoveAt(i);
        }
    }
    qbcDataGridView.DataSource = dt;
