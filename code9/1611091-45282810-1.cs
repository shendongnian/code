    var a = new FrameworkElementFactory(typeof(ContentControl));
    a.SetValue(ContentControl.ContentProperty, new ViewModelColumn("a"));
    ((GridView)listView.View).Columns.Add(new GridViewColumn
    {
        Header = "a",
        CellTemplate = new DataTemplate { VisualTree = a }
    });
