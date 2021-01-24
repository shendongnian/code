    button.SetValue(Button.CommandProperty, new Binding("DataContext.CloseCommand")
    {
        RelativeSource = new RelativeSource { AncestorType = typeof(TabControl) },
    });
    button.SetValue(Button.CommandParameterProperty, new Binding("Header"));
