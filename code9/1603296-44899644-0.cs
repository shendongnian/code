    tableLayoutPanel1.AutoSize = true; // This can be set at the end if you use designer
    tableLayoutPanel1.ColumnCount = 1;
    tableLayoutPanel1.RowCount = 1;
    tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
    panel1.Controls.Add(tableLayoutPanel1); // add TableLayoutPanel to your panel
    tableLayoutPanel1.Controls.Add(label1, 0, 0); // Add your label to TableLayout
