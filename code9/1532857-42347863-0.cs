    public interface ICustomCommand
    {
        void Execute();
    }
    public static class CustomCommandEx
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICustomCommand),
                typeof(CustomCommandEx),
                new PropertyMetadata(CommandPropertyChanged));
        public static ICustomCommand GetCommand(DependencyObject obj)
        {
            return (ICustomCommand)obj.GetValue(CommandProperty);
        }
        public static void SetCommand(DependencyObject obj, ICustomCommand value)
        {
            obj.SetValue(CommandProperty, value);
        }
        private static void CommandPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs eventArgs)
        {
            var button = obj as ButtonBase;
            var command = eventArgs.NewValue as ICustomCommand;
            if (button != null)
            {
                button.Click += (s, e) => command.Execute();
            }
        }
    }
