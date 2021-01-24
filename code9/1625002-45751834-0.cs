    private void btnUnselectall_Click(object sender, RoutedEventArgs e)
    {
        foreach (var a in authorityList)
        {
            a.IsChecked = false;
        }
    }
    private void btnSelectAll_Click(object sender, RoutedEventArgs e)
    {
        foreach (var a in authorityList)
        {
            a.IsChecked = true;
        }
    }
