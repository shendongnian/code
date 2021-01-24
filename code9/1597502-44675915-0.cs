            ToolStripItem partyMaster = new ToolStripMenuItem() { Text = "Party Master" };
            partyMaster.Click += MenuClicked;
            ToolStripItem itemMaster = new ToolStripMenuItem() { Text = "Item Master" };
            itemMaster.Click += MenuClicked;
            ToolStripItem taxMaster = new ToolStripMenuItem() { Text = "Tax Master" };
            taxMaster.Click += MenuClicked;
            master.DropDownItems.Add(partyMaster);
            master.DropDownItems.Add(itemMaster);
            master.DropDownItems.Add(taxMaster);
