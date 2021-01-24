    button.SetValue(Button.CommandProperty, new Binding("CloseCommand")
    {
        RelativeSource = new RelativeSource { AncestorType = typeof(TabControl) },
    });
    button.SetValue(Button.CommandParameterProperty, new Binding("Header"));
