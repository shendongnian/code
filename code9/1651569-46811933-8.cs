    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.Shapes.Add(new EllipseGeometry(new Point(50, 50), 15, 15));
        vm.Shapes.Add(new RectangleGeometry(new Rect(85, 85, 30, 30)));
        vm.Shapes.Add(new EllipseGeometry(new Point(150, 150), 15, 15));
        DataContext = vm;
    }
