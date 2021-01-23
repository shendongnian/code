        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0) // Also you can check for specific row by e.RowIndex
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All
                    & ~( DataGridViewPaintParts.ContentForeground));
                var r = e.CellBounds;
                r.Inflate(-4, -4);
                e.Graphics.FillRectangle(Brushes.Blue, r);
                e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
                e.Handled = true;
            }
        }
