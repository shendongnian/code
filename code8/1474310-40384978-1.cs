    private void Form1_Load(object sender, EventArgs e)
    {
        var dropdown = new ToolStripDropDown();
        //Define style
        dropdown.LayoutStyle = ToolStripLayoutStyle.Table;
        var settings = (dropdown.LayoutSettings as TableLayoutSettings);
        settings.ColumnCount = 3;
        //First Item    
        var item1 = new ToolStripMenuItem("Some Sub Menu");
        dropdown.Items.Add(item1);
        settings.SetColumnSpan(item1, 3); //Set column span to fill the row
        //First Combo
        var combo1 = new ToolStripComboBox("combo1");
        combo1.Items.AddRange(new string[] { "Item1", "Item2", "Item3" });
        dropdown.Items.Add(combo1);
        //Separator
        dropdown.Items.Add("-");
        //Second Combo
        var combo2 = new ToolStripComboBox("combo2");
        combo2.Items.AddRange(new string[] { "Item1", "Item2", "Item3" });
        dropdown.Items.Add(combo2);
        //Last item
        var item2 = new ToolStripMenuItem("Some Othe Sub Menu");
        dropdown.Items.Add(item2);
        settings.SetColumnSpan(item2, 3); //Set column span to fill the row
        toolStripDropDownButton1.DropDown = dropdown;
    }
