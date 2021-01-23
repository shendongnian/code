    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ViewModel.VMText
        {
            CodeString = "Hello World!\nHow you doin'?"
        };
    }
