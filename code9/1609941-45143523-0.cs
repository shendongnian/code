    da.Fill(dt);
    dataGridView1.DataSource = dt.DefaultView;
    dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
         foreach(DataGridViewColumn dc in dataGridView1.Columns)
                    {
                        dc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
     dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
