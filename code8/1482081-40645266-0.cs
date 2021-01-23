    public Form1()
    {
        InitializeComponent();
		ToolStripComboBox item1 = new ToolStripComboBox();
		item1.Items.AddRange(new object[]
		{
			"One",
			"Two",
			"Thtree"
		});
		item1.DropDownStyle = ComboBoxStyle.Simple;
		menuStrip1.Items.Add(item1);
		ToolStripMenuItem item2 = new ToolStripMenuItem();
		item2.Text = "Four";
		menuStrip1.Items.Add(item2);
    }
