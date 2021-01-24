    public MainWindow()
    {
        InitializeComponent();
        MenuItem mi = new MenuItem() { Header = "test" };
        mi.Click += MenuItem_Click_1;
        recents.Items.Add(mi);
    }
    private void MenuItem_Click_1(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("clicked!");
    }
