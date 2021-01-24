    for (int i = 0; i < dataGridView1.RowCount; i++)
    {
        var cell = dataGridView1[0, i];
        if (cell.Value != null)
            cell.Value = string.Join("/", cell.Value.ToString().Split('.').Select(s => s.PadLeft(5, '\t')));
    }
    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
