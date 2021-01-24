    protected override void OnPaint(object sender, PaintEventArgs e)
    {
        DataGridViewCell cell = dataGridView1[0, 2];  // <-- use the correct indices!!
        if (cell is DataGridViewCheckBoxCell && cell.Value != null)
        {
            bool c = (bool)(cell as DataGridViewCheckBoxCell).Value;
            Pen myPen = c ? Pens.Yellow : Pens.Snow;
            e.Graphics.DrawLine(myPen, 160, 285, 250, 285);
        }
    }
