    private void ListViewLocalSystem_Click(object sender, RoutedEventArgs e)
    {
        GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
        if (headerClicked != null)
        {
            GridViewHeaderRowPresenter presenter = headerClicked.Parent as GridViewHeaderRowPresenter;
            if (presenter != null)
            {
                int zeroBasedDisplayIndex = presenter.Columns.IndexOf(headerClicked.Column);
                ...
            }
        }
    }
