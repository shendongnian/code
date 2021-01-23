    public DataTable dt { get; set; }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
       dtGrid.ItemsSource = dt.DefaultView; //dtGrid is the DataGrid
    }
