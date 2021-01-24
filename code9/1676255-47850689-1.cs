    public static class ExecutesCommandOnLeftClickBehavior
    {
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }
        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }
        
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(ExecutesCommandOnLeftClickBehavior),
            new PropertyMetadata(null, OnCommandPropertyChanged));
        private static void OnCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            if (element == null) return;
            element.MouseLeftButtonDown -= OnMouseLeftButtonDown;
            element.MouseLeftButtonDown += OnMouseLeftButtonDown;
        }
        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element == null) return;
            ICommand command = GetCommand(element);
            if (command == null) return;
            if (command.CanExecute(null))
                command.Execute(null);
        }
    }
