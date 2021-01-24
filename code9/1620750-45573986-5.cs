    protected override void OnPaint(object sender, PaintEventArgs e)
    {
        // test if data are loaded:
        if (! (dataGridView1.RowCount > 0  && dataGridView1dgv.ColumnCount > 2)) return;
        DataGridViewCell cell = dataGridView1[0, 2];  // <-- use the correct indices!!
        if (cell is DataGridViewCheckBoxCell && cell.Value != null)
        {
            bool c = (bool)(cell as DataGridViewCheckBoxCell).Value;
            Pen myPen = c ? Pens.Yellow : Pens.Snow;
            e.Graphics.DrawLine(myPen, 160, 285, 250, 285);
        }
    }
