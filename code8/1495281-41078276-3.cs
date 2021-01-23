    public MainWindow()
    {
        InitializeComponent();
    
        for (var i = 0; i < 20; i++)
            StudentGrid.Children.Add(new StudentControl($"Student{i + 1}"));
    }
