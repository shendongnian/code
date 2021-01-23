    var panel1 = new TableLayoutPanel();
    panel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
    panel1.RowCount = 2;
    panel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
    panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
    panel1.AutoSize = true;
    panel1.AutoSizeMode= System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    var groupBox1 = new GroupBox() { Text = "GroupBox" };
    groupBox1.AutoSize = true;
    groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    var panel2 = new TableLayoutPanel() {Top= 24, Left= 5 };
    panel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
    panel2.AutoSize = true;
    panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    groupBox1.Controls.Add(panel2);
    panel1.Controls.Add(new Label() { Text = "Label" });
    panel1.Controls.Add(groupBox1);
    this.SuspendLayout();
    this.Controls.Add(panel1);
    this.AutoScroll = true;
    for (int i = 0; i < 10; i++)
    {
        panel2.RowCount += 1;
        panel2.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel2.Controls.Add(new GroupBox()
        {
            Text = string.Format("GroupBox{0}", i + 1)
        });
    }
    this.ResumeLayout(true);
