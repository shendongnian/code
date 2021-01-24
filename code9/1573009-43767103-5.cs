    private void Execute(object sender, RoutedEventArgs e)
    {
        var cellItem = ((Button)sender).DataContext as GridCellItem;
        //  Replace this with code that does something useful, of course. 
        MessageBox.Show($"User clicked cell at row {cellItem.Row}, column {cellItem.Col}, with value {cellItem.Value}");
    }
