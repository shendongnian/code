    protected override void OnStartup(StartupEventArgs e)
    {
        // ...
        EventManager.RegisterClassHandler(typeof(TextBox),
            UIElement.GotFocusEvent, new RoutedEventHandler(OnTextBoxGotFocus));
    }
    
    private static void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox && !textBox.IsReadOnly)
        {
            textBox.SelectAll();
        }
    }
