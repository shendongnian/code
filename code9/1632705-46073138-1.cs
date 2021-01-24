    public MainWindow()
    {
        InitializeComponent();
        PointCollection pc = new PointCollection();
        for (int i = 0; i < 100; i++)
        {
            pc.Add(new System.Windows.Point { X = i, Y = i * 2 });
        }
        // in some appropriate datacontext, set some object that contains your points collection for the binding
        chart1.DataContext = new { points = pc };
    }
