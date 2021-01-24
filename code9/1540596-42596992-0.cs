    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
        {
            if (e.Value != null && e.Value.ToString() == "ddd")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            }
        }
    }
