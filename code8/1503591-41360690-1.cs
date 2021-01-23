    Binding bind = new Binding() { Path = new PropertyPath(prop.Name), Source = this };
    if (prop.CanWrite)
    {
        TextBox.SetBinding(TextBox.TextProperty, bind);
    }
    else
    {
        TextBox.IsEnabled = false;
    }
