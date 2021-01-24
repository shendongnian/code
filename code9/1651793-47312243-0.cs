        private void gridSelection_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            TabPage currentPage = tabs.SelectedTab;
            DataGridView currentGrid = currentPage.Controls[0] as DataGridView;
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && currentGrid[e.ColumnIndex, e.RowIndex].Selected)
            {
                using (Pen borderPen = new Pen(Color.Black, 2))
                {
                    Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
                    // Erase the cell.
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    Rectangle rectDimensions = e.CellBounds;
                    rectDimensions.Width -= 2;
                    rectDimensions.Height -= 2;
                    rectDimensions.X = rectDimensions.Left + 1;
                    rectDimensions.Y = rectDimensions.Top + 1;
                    e.Graphics.DrawRectangle(borderPen, rectDimensions);
                    // Draw the text content of the cell, ignoring alignment.
                    if (e.Value != null)
                    {
                        Brush textColor = new SolidBrush(e.CellStyle.ForeColor);
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                            textColor, e.CellBounds.X +1,
                            e.CellBounds.Y + 3, StringFormat.GenericDefault);
                    }
                    e.Handled = true;
                }
            }
        }
