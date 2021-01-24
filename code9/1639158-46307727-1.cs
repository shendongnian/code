    var headerTemplate = new DataTemplate();
    var label = new FrameworkElementFactory(typeof(Label));
    label.SetBinding(Label.ContentProperty, new Binding());
    label.SetValue(Label.MarginProperty, new Thickness(16, 12, 16, 12));
    headerTemplate.VisualTree = label;
    functionReturnValue.Setters.Add(new Setter(TabItem.HeaderTemplateProperty, headerTemplate));
