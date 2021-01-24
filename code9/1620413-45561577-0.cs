    private void ItemRightClick(object sender, EventArgs e)
    {
        MenuItem item = sender as MenuItem;
        if (item!= null)
        {
            ContextMenu contextMenu = item.GetContextMenu();
            Control clickedControl = contextMenu.SourceControl;
        }
    }
