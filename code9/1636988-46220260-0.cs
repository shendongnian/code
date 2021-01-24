    private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        . . .
        TabControl_SelectionChanged(yourTabControl, new System.Windows.Controls.SelectionChangedEventArgs());
        . . .
    }
