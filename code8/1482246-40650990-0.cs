    if (tbObjects.Text == "")
    {
        var myBinding = new LocExtension("Var1");
        BindingOperations.SetBinding(tbObjects, TextBox.TextProperty, myBinding);
        tbObjects.Foreground = new SolidColorBrush(Colors.Gray);
    }
