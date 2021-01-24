    private void listViewWithContextMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
        var list = sender as ListView;
        list.ContextMenu.DataContext = list.SelectedItem;
    }
