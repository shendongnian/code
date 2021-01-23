    var dt = new DataTemplate();
    var t1 = new Trigger()
    {
        SourceName = "source",
        Property = IsMouseOverProperty,
        Value = true
    };
    t1.Setters.Add(new Setter(BorderBrushProperty, Brushes.Black, "target"));
    t1.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(4.0), "target"));
    dt.Triggers.Add(t1);
