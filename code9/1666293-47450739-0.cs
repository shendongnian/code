    int Count = 0;
    foreach (ToolStripDropDownItem mnu in entriesToolStripMenuItem.DropDownItems)
    {
        if (mnu.Tag==1)
        {
            Count++;
        }
    }
    if (Count == 0)
    {
        entriesToolStripMenuItem.Visible = false;
    }
