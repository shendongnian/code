    private void ItemRightClick(object sender, EventArgs e)
    {
        MenuItem item = sender as MenuItem;
        if (item!= null)
        {
            ContextMenu contextMenu = item.Parent;
            Control clickedControl = contextMenu.SourceControl;
        }
    }
