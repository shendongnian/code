    private void DataGrid_ContextMenuOpening_1(object sender, ContextMenuEventArgs e)
        {
            ContextMenu ctxmenu = (sender as DataGrid).ContextMenu;
            // suppress ContextMenu if empty
            e.Handled  = ctxmenu.Items.Count == 0;            
        }
    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu ctxmenu = Dgrd.ContextMenu;
            MenuItem mi = new MenuItem();
            mi.Header = "hallo";
            ctxmenu.Items.Add(mi);
        }
