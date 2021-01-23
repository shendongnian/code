    private static void ButtonChangedCallback(object sender, DependencyPropertyChangedEventArgs args)
    {
        // Get button defined by user in MainWindow
        Button userButton = (Button)args.NewValue;
        // Get template button in UserControl
        UserControl template = (UserControl)sender;
        Button templateButton = (Button)template.FindName("button");
        // Get userButton props and change templateButton accordingly
        List<DependencyProperty> properties = GetDependencyProperties(userButton);
        foreach (DependencyProperty property in properties)
        {
        if (templateButton.GetValue(property) != userButton.GetValue(property))
            templateButton.SetValue(property, userButton.GetValue(property));
        }
        // Set Content binding
        BindingExpression bindingExpression = userButton.GetBindingExpression(Button.ContentProperty);
        if (bindingExpression != null)
            templateButton.SetBinding(Button.ContentProperty, bindingExpression.ParentBinding);
    }
