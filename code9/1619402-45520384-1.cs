    private static void DisableItem(ToolStripDropDownItem menu, bool enable, string text)
    {
        if (!menu.HasDropDownItems)
            if (Equals(menu.Text, text))
                menu.Enabled = enable;
            else
                return;
        foreach(var subItem in menu.DropDownItems)
        {
            var item = subItem as ToolStripDropDownItem;
            if (item == null) continue; 
            if (item.HasDropDownItems)
                DisableItem(item, enable, text);
            if (Equals(item.Text, text))
                item.Enabled = enable;
        }
    }
