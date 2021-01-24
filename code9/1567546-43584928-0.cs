    private void listViewItem_MouseDown(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource is Image)
            return; // do nothing
        MessageBox.Show("ROW CLICKED");
    }
