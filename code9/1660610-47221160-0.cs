    private void OnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        for (int i = 0; i < _numPricingColumns; i++)
        {
            var name = $"Price {i + 1}";
            var column = GridView.Columns[name];
            if (column.Index == e.ColumnIndex && e.RowIndex >= 0)
            {
                var row = GridView.Rows[e.RowIndex];
                var record = row.DataBoundItem as PricingRecord;
                if (record != null)
                {
                    var selected = (e.State & DataGridViewElementStates.Selected) != 0;
                    using (var brush = new SolidBrush(selected ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor))
                    {
                        e.PaintBackground(e.ClipBounds, selected);
                        e.Graphics.DrawString(record.Prices[i].ToString("N"), e.CellStyle.Font, brush,
                            e.CellBounds.X + 2.0f, e.CellBounds.Y + 2.0f, StringFormat.GenericDefault);
                        e.Handled = true;
                    }
                }
            }
        }
    }
