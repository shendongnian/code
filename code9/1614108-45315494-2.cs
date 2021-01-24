    private void RenderNameCell (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
    {
        SVDMMR.ModInfo modinfo = (SVDMMR.ModInfo) model.GetValue (iter, 0);
        (cell as Gtk.CellRendererText).Text = modinfo.name;
    }
    private void RenderValueCell (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
    {
        // You didn't say what the value is so lets use UniqueID
        SVDMMR.ModInfo modinfo = (SVDMMR.ModInfo) model.GetValue (iter, 0);
        (cell as Gtk.CellRendererText).Text = modinfo.UniqueID;
    }
