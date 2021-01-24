    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridView1.CurrentCell.ColumnIndex
                && e.RowIndex == this.dataGridView1.CurrentCell.RowIndex)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All& ~DataGridViewPaintParts.Border);
                using (Pen p = new Pen(Color.Black, 0))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 2;
                    rect.Height -= 2;
                    e.Graphics.DrawRectangle(p, rect);
                }
                e.Handled = true;
            }
        }
