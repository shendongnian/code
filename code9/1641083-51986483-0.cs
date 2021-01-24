    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        foreach (ToolStripMenuItem item in ((ToolStrip)sender).Items)
        {
            if (item != e.ClickedItem)
                item.BackColor = Color.White;
            else
                item.BackColor = Color.Cyan;
        }
    }
