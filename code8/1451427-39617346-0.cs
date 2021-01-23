    DataGridView grid = (DataGridView)sender;
            System.Drawing.Font rowFont = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
            dynamic centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Far;
            centerFormat.LineAlignment = StringAlignment.Near;
            string rowIdx = (grid.Rows.Count - e.RowIndex).ToString(); //you can get the row count and subtract it.
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat);
