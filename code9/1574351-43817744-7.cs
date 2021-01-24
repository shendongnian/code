    button.SetBinding(Button.CommandProperty, new Binding("DataContext.CloseCommand")
    {
        RelativeSource = new RelativeSource { AncestorType = typeof(TabControl) },
    });
    button.SetBinding(Button.CommandParameterProperty, new Binding("Header"));
