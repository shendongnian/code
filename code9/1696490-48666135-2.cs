    FrameworkElementFactory imgFactory = new FrameworkElementFactory(typeof(Image));
    imgFactory.SetValue(Image.HeightProperty, 50.0);
    imgFactory.SetValue(Image.WidthProperty, 50.0);
    imgFactory.SetBinding(Image.SourceProperty, new Binding("Column2Img"));
    FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(StackPanel));
    spFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
    spFactory.AppendChild(imgFactory);
