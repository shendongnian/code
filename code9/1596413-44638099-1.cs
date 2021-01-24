    private DataTable ToDataTable(DataGridView dataGridView)
    {
        var dt = new DataTable();
        foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
        {
            if (dataGridViewColumn.Visible)
            {
                dt.Columns.Add();
            }
        }
        var cell = new object[dataGridView.Columns.Count];
        foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
        {
            for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
            {
                cell[i] = dataGridViewRow.Cells[i].Value;
            }
            dt.Rows.Add(cell);
        }
        return dt;
    }
