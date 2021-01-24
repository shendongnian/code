    private void InvalidateHeader()
    {
        Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
        rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
        this.dataGridView1.Invalidate(rtHeader);
    }
    private void DataGridView1_Resize(object sender, EventArgs e)
    {
        this.InvalidateHeader();
    }
    private void DataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        this.InvalidateHeader();
    }
    private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
    {
        this.InvalidateHeader();
    }
    private void DataGridView1_Paint(object sender, PaintEventArgs e)
    {
        int col = 0;
        // For each month, create the display rectangle for the main title and draw it.
        foreach (int daysInMonth in daysInMonths)
        {
            Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(col, -1, true);
            // Start the rectangle from the first visible day of the month,
            // and add the width of the column for each following day.
            for (int day = 0; day < daysInMonth; day++)
            {
                Rectangle r2 = this.dataGridView1.GetCellDisplayRectangle(col + day, -1, true);
                if (r1.Width == 0) // Cell is not displayed.
                {
                    r1 = r2;
                }
                else
                {
                    r1.Width += r2.Width;
                }
            }
            r1.X += 1;
            r1.Y += 1;
            r1.Height = r1.Height / 2 - 2;
            r1.Width -= 2;
            using (Brush back = new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor))
            using (Brush fore = new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor))
            using (Pen p = new Pen(this.dataGridView1.GridColor))
            using (StringFormat format = new StringFormat())
            {
                string month = DateTime.Parse(this.dataGridView1.Columns[col].Name).ToString("MMMM");
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.FillRectangle(back, r1);
                e.Graphics.DrawRectangle(p, r1);
                e.Graphics.DrawString(month, this.dataGridView1.ColumnHeadersDefaultCellStyle.Font, fore, r1, format);
            }
            col += daysInMonth; // Move to the first column of the next month.
        }
    }
