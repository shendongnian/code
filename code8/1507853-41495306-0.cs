    public SendButton(string buttonText, RoutedEventHandler clickHandler)
    {
        InitializeComponent();
        ButtonBlock.Content = buttonText;
        ButtonBlock.Click += clickHandler;
    }
