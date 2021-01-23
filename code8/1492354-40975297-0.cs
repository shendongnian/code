    private void ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = sender as ContextMenu;
            GridViewColumnHeader header = contextMenu.PlacementTarget as GridViewColumnHeader;
            if (e.Source == btnAsc)
            {
                Sort(header, true);
            }
            else
            {
                Sort(header, false);
            }
        }
