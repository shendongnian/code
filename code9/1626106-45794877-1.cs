    public MainWindow()
    {
        InitializeComponent();
        randy_container.Child = CreateRandyButton();
    }
    private void end_Click(object sender, RoutedEventArgs e)
    {
        StackPanel s = new StackPanel();
        s.Children.Add(CreateRandyButton());
    }
    private Button CreateRandyButton()
    {
        Button button = new Button { Name = "randy", Content = "I am a Randy, the button", ToolTip = "Meet Randy" };
        button.Click += randy_Click;
        return button;
    }
