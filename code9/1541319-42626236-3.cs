    var factory = new FrameworkElementFactory(typeof(Image));
    factory.SetValue(Image.SourceProperty, new Binding(nameof(XData.Path)));
    factory.SetValue(Image.WidthProperty, 100.0);
    factory.SetValue(Image.HeightProperty, 100.0);
    var dataTemplate = new DataTemplate { VisualTree = factory };
