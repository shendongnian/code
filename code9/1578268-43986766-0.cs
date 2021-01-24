    // ...
    dt.Rows.Add(new object[] { 3, null, null });
    this.dataGridView1.DataSource = dt;
    this.dataGridView1.CellPainting += DataGridView1_CellPainting;
----------
    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            DataGridViewCell cell = this.dataGridView1[e.ColumnIndex, e.RowIndex];
            if (cell.Value == null || cell.Value is DBNull)
            {
                using (SolidBrush brush = new SolidBrush(this.dataGridView1.BackgroundColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                e.Handled = true;
            }
        }
    }
