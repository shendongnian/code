    private void MergeCellsInRow(int row, int col1, int col2)
    {
        Graphics g = dataGridView1.CreateGraphics();
        Pen p = new Pen(dataGridView1.GridColor);
        Rectangle r1 = dataGridView1.GetCellDisplayRectangle(col1, row, true);
        Rectangle r2 = dataGridView1.GetCellDisplayRectangle(col2, row, true);
     
        int recWidth = 0;
        string recValue = string.Empty;
        for (int i = col1; i <= col2; i++)
        {
        recWidth += dataGridView1.GetCellDisplayRectangle(i, row, true).Width;
        if (dataGridView1[i, row].Value != null)
            recValue += dataGridView1[i, row].Value.ToString() + " ";
        }
        Rectangle newCell = new Rectangle(r1.X, r1.Y, recWidth, r1.Height);
        g.FillRectangle(new SolidBrush(dataGridView1.DefaultCellStyle.BackColor), newCell);
        g.DrawRectangle(p, newCell);
        g.DrawString(recValue, dataGridView1.DefaultCellStyle.Font, new SolidBrush(dataGridView1.DefaultCellStyle.ForeColor), newCell.X + 3, newCell.Y + 3);
    }
     
    private void MergeCellsInColumn(int col, int row1, int row2)
    {
        Graphics g = dataGridView1.CreateGraphics();
        Pen p = new Pen(dataGridView1.GridColor);
        Rectangle r1 = dataGridView1.GetCellDisplayRectangle(col, row1, true);
        Rectangle r2 = dataGridView1.GetCellDisplayRectangle(col, row2, true);
     
        int recHeight = 0;
        string recValue = string.Empty;
        for (int i = row1; i <= row2; i++)
        {
        recHeight += dataGridView1.GetCellDisplayRectangle(col, i, true).Height;
        if (dataGridView1[col, i].Value != null)
            recValue += dataGridView1[col, i].Value.ToString() + " ";
        }
        Rectangle newCell = new Rectangle(r1.X, r1.Y, r1.Width, recHeight);
        g.FillRectangle(new SolidBrush(dataGridView1.DefaultCellStyle.BackColor), newCell);
        g.DrawRectangle(p, newCell);
        g.DrawString(recValue, dataGridView1.DefaultCellStyle.Font, new SolidBrush(dataGridView1.DefaultCellStyle.ForeColor), newCell.X + 3, newCell.Y + 3);
    }
