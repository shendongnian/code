    private void cOMToolStripMenuItem_MouseHover(object sender, EventArgs e)
    {
        cOMToolStripMenuItem.DropDownItems.Clear(); 
        foreach (var item in ports)
        {
            ToolStripItem subItem = new ToolStripMenuItem(item);
            cOMToolStripMenuItem.DropDownItems.Add(subItem);
        }
    }
