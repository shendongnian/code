    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.Shapes.Add(new EllipseGeometry(new Point(50, 50), 15, 15));
        DataContext = vm;
    }
