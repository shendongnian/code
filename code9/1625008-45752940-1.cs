    private void btnUnselectall_Click(object sender, RoutedEventArgs e)
    {
        Select(false);
    }
    private void btnSelectAll_Click(object sender, RoutedEventArgs e)
    {
        Select(true);
    }
    private void Select(bool select)
    {
        foreach (Authority authority in authorityList)
            authority.IsChecked = select;
    }
