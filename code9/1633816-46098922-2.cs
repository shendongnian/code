    public class DoubleTappedBehavior
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(DoubleTappedBehavior), new PropertyMetadata(null, OnCommandChanged));
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(DoubleTappedBehavior), new PropertyMetadata(null));
        private static void OnCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var element = target as UIElement;
            if (element != null)
            {
                element.DoubleTapped -= OnDoubleTapped;
                element.DoubleTapped += OnDoubleTapped;
            }
        }
        private static void OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var element = sender as UIElement;
            if (element != null)
            {
                var command = GetCommand(element);
                var commandParameter = GetCommandParameter(element);
                if (command != null)
                {
                    if (command.CanExecute(commandParameter))
                    {
                        command.Execute(commandParameter);       
                    }
                }
            }
        }
        public static void SetCommand(UIElement target, ICommand value) => target.SetValue(CommandProperty, value);
        public static ICommand GetCommand(UIElement target) => (ICommand)target.GetValue(CommandProperty);
        public static void SetCommandParameter(UIElement target, object value) => target.SetValue(CommandProperty, value);
        public static object GetCommandParameter(UIElement target) => target.GetValue(CommandParameterProperty);
    }
