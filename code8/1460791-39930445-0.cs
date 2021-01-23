    public MainWindow()
        {
            InitializeComponent();
            Button EditButton = new Button();
            EditButton.Margin = new System.Windows.Thickness(10, 10, 0, 0);
            EditButton.Height = double.Parse("20");
            EditButton.Width = double.Parse("20");
            EditButton.Cursor = System.Windows.Input.Cursors.Hand;
            EditButton.Content = "TEST!";
            EditButton.Click += new System.Windows.RoutedEventHandler(Edit_Click);
            Grid.Children.Add(EditButton);
          //  Location[1] += 17;
        }
    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
