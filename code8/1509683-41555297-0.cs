    ObservableCollection<string> _items = new ObservableCollection<string>();
    
    //  Or whatever your constructor is
    public MainWindow()
    {
        recipientLb.ItemsSource = _items;
    }
    
    private void addBtn_Click(object sender, RoutedEventArgs e)
    {
        _items.Add(recipentTextbox.Text);
    }
