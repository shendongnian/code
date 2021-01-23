    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new ViewModel();
        viewModel.Shapes.Add(new ShapeData
        {
            Type = "Circle",
            Geometry = new EllipseGeometry(new Point(100, 100), 50, 50),
            Fill = Brushes.Orange,
            Stroke = Brushes.Navy,
            StrokeThickness = 2
        });
        viewModel.Shapes.Add(new ShapeData
        {
            Type = "Rectangle",
            Geometry = new RectangleGeometry(new Rect(200, 50, 50, 100)),
            Fill = Brushes.Yellow,
            Stroke = Brushes.DarkGreen,
            StrokeThickness = 2
        });
        DataContext = viewModel;
    }
