    private void dataGridView1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        foreach(var t in DgvCells)
        {
            if (!(t.Item1.Displayed && t.Item2.Displayed)) continue;
            Point p1 = GetCenter(dataGridView1.GetCellDisplayRectangle(
                                               t.Item1.ColumnIndex, t.Item1.RowIndex, true));
            Point p2 = GetCenter(dataGridView1.GetCellDisplayRectangle(
                                               t.Item2.ColumnIndex, t.Item2.RowIndex, true));
            using (Pen pen = new Pen(Color.Blue, 1) 
                  { EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor })
                e.Graphics.DrawLine(pen, p1, p2);
        }
    }
