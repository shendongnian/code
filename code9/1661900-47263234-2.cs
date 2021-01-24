    private void dgv1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        var grid = (DataGridView)sender;
        var sortIconColor = Color.Red;
        if (e.RowIndex == -1 && e.ColumnIndex > -1)
        {
            using (var b = new SolidBrush(BackColor))
            {
                //Draw Background
                e.PaintBackground(e.CellBounds, false);
                //Draw Text Default
                //e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
                //Draw Text Custom
                TextRenderer.DrawText(e.Graphics, string.Format("{0}", e.FormattedValue),
                    e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                //Draw Sort Icon
                if (grid.SortedColumn?.Index == e.ColumnIndex)
                {
                    var sortIcon = grid.SortOrder == SortOrder.Ascending ? "▲":"▼";
                    //Or draw an icon here.
                    TextRenderer.DrawText(e.Graphics, sortIcon,
                        e.CellStyle.Font, e.CellBounds, sortIconColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                }
                //Prevent Default Paint
                e.Handled = true;
            }
        }
    }
