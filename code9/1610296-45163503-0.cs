    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        SelectAll(true);
    }
    private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        SelectAll(false);
    }
    private void SelectAll(bool select)
    {
        var all = listBoxList.ItemsSource as IEnumerable<AddSource>;
        if (all != null)
        {
            foreach (var source in all)
                source.IsSelected = select;
        }
    }
