    private void TopListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        BottomListBox.SelectedItem = null;
        TopListBox.SelectedItem = e.AddedItems.FirstOrDefault();
    }
    private void BottomListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TopListBox.SelectedItem = null;
        BottomListBox.SelectedItem = e.AddedItems.FirstOrDefault();
    }
