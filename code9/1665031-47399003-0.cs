    public static class NavigationRadioButtonHelper
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                name: "Command",
                propertyType: typeof(ICommand),
                ownerType: typeof(NavigationRadioButtonHelper),
                defaultMetadata: new PropertyMetadata(null, HandleCommandChanged));
        public static ICommand GetCommand(NavigationRadioButton control)
            => (ICommand)control.GetValue(CommandProperty);
        public static void SetCommand(NavigationRadioButton control, ICommand value)
            => control.SetValue(CommandProperty, value);
        private static void HandleCommandChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                ((NavigationRadioButton)d).AddHandler(
                    routedEvent: Mouse.PreviewMouseDownEvent,
                    handler: (MouseButtonEventHandler)HandlePreviewMouseDown);
            }
            else
            {
                ((NavigationRadioButton)d).RemoveHandler(
                    routedEvent: Mouse.PreviewMouseDownEvent,
                    handler: (MouseButtonEventHandler)HandlePreviewMouseDown);
            }
        }
        private static void HandlePreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var control = (NavigationRadioButton)sender;
            var command = GetCommand(control);
            var parameter = $"{control.RegionName},{control.ViewName}";
            if (command != null && command.CanExecute(parameter))
                command.Execute(parameter);
        }
    }
