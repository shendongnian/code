    public static void DisableItem(ToolStripMenuItem menu, bool enable, string name)
    {
        if (!menu.HasDropDownItems)
            if (Equals(menu.Name, name))
                menu.Enabled = enable;
            else
                return;
        foreach(ToolStripMenuItem subItem in menu.DropDownItems)
        {
            if (subItem.HasDropDownItems)
                DisableItem(subItem, enable, name);
            if (Equals(subItem.Name, name))
                subItem.Enabled = enable;
        }
    }
