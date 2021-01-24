    private void Form1_Load(object sender, EventArgs e)
    {
        var menuStrip = new MenuStrip() { Dock = DockStyle.Top };
        this.Controls.Add(menuStrip);
        var menu1 = (ToolStripMenuItem)menuStrip.Items.Add("Menu1");
        menu1.DropDownItems.Add(new ToolStripMenuItem("Submenu1")
            { Tag = "keepopen", CheckOnClick = true });
        menu1.DropDownItems.Add(new ToolStripMenuItem("Submenu2")
        { Tag = "keepopen", CheckOnClick = true });
        menu1.DropDownItems.Add(new ToolStripMenuItem("Submenu3")
        { Tag = "keepopen", CheckOnClick = true });
        menu1.DropDownItems.Add("-");
        menu1.DropDownItems.Add(new ToolStripMenuItem("Submenu4"));
        menu1.DropDown.ItemClicked += (obj, args) =>
        {
            if (args.ClickedItem.Tag == "keepopen")
                menu1.DropDown.AutoClose = false;
            else
                menu1.DropDown.AutoClose = true;
        };
        menu1.DropDownItems.OfType<ToolStripMenuItem>()
            .Where(x => x.Tag == "keepopen")
            .ToList().ForEach(x =>
            {
                x.CheckedChanged += (obj, args) =>
                {
                    menu1.DropDown.AutoClose = true;
                };
            });
    }
