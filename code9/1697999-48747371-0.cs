    private DataTemplate PushPinPointDataTemplate()
    {
        var pointItemFactory = new FrameworkElementFactory(typeof(MapItem));
        pointItemFactory.SetValue(MapPanel.LocationProperty, new Binding("."));
        var pathFactory = new FrameworkElementFactory(typeof(Path));
        pathFactory.SetValue(Path.StrokeThicknessProperty, 2.0);
        pathFactory.SetValue(Path.FillProperty, Brushes.Yellow);
        pathFactory.SetValue(Path.DataProperty, new EllipseGeometry { RadiusX = 3, RadiusY = 3 });
        var pointCanvasFactory = new FrameworkElementFactory(typeof(Canvas));
        pointCanvasFactory.AppendChild(pathFactory);
        pointItemFactory.AppendChild(pointCanvasFactory);
        return new DataTemplate
        {
            DataType = typeof(Location),
            VisualTree = pointItemFactory
        };
    }
