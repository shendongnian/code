    private void Execute(object sender, RoutedEventArgs e)
    {
        var cellItem = ((Button)sender).DataContext as GridCellItem;
        MessageBox.Show($"User clicked cell at row {cellItem.Row}, column {cellItem.Col}, with value {cellItem.Value}");
    }
