    private void button1_Click(object sender, EventArgs e)
    {
        var fields = new string[] { "A Field", "Some Field", "Another Field",
            "A Long Field Name", "A Long Long Field Name" };
        var tlp = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 4 };
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        panel1.Controls.Add(tlp);
        foreach (var item in fields)
        {
            tlp.Controls.Add(new Label() { Text = item, AutoSize = true });
            tlp.Controls.Add(new TextBox() { Dock = DockStyle.Fill });
        }
    }
