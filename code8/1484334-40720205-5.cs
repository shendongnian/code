    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.ShapeItems.Add(new ShapeItem
        {
            Geometry = new LineGeometry(new Point(100, 100), new Point(200, 200)),
            Stroke = Brushes.Green
        });
        vm.ShapeItems.Add(new ShapeItem
        {
            Geometry = new LineGeometry(new Point(200, 200), new Point(100, 300)),
            Stroke = Brushes.Red
        });
        DataContext = vm;
    }
