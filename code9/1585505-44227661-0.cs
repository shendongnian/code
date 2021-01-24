    var ellipse = new Ellipse();
    var binding = new Binding(Ellipse.ActualHeightProperty.Name)
    {
        RelativeSource = new RelativeSource(RelativeSourceMode.Self),
        Mode = BindingMode.OneWay
    };
    ellipse.VerticalAlignment = VerticalAlignment.Stretch;
    ellipse.HorizontalAlignment = HorizontalAlignment.Center;
    BindingOperations.SetBinding(ellipse, Ellipse.WidthProperty, binding);
