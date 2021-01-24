    int gridWidth = 0;
    int gridHeight = 0;
    
    foreach (DataGridViewColumn col in dataGridView1.Columns)
    {
        gridWidth += col.Width;
    }
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        gridHeight += row.Height;
    }
