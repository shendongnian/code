    tableLayoutPanel1.SuspendLayout();
    // adapt styling of first row
    if (tableLayoutPanel1.RowStyles.Count > 0)
    {
        tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;
        tableLayoutPanel1.RowStyles[0].Height = 25F;
    }
    for(int i=0; i<100; i++)
    {
        var lbl = new Label();
        lbl.Text = i.ToString();
        tableLayoutPanel1.Controls.Add(lbl, 0, i);
                 
        var num = new NumericUpDown();
        tableLayoutPanel1.Controls.Add(num,1 ,i);
                 
        tableLayoutPanel1.RowCount++;
    }
                
    tableLayoutPanel1.ResumeLayout();
