    private void GridViewColumnHeaderClicked(object sender, RoutedEventArgs e)
    {
        GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
        if (headerClicked == null)
            return;
        if (headerClicked.Role == GridViewColumnHeaderRole.Padding)
            return;
        //  ...if DisplayMemberPath is null...
        var sortingColumn = GridViewExt.GetSortColumnPath(headerClicked.Column);
        if (sortingColumn == null)
            return;
