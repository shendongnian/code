    public class Attached
    {
        public static ICommand GetDoubleClickCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(DoubleClickCommandProperty);
        }
    
        public static void SetDoubleClickCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(DoubleClickCommandProperty, value);
        }
    
        public static object GetDoubleClickCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(DoubleClickCommandParameterProperty);
        }
    
        public static void SetDoubleClickCommand(DependencyObject obj, object value)
        {
            obj.SetValue(DoubleClickCommandParameterProperty, value);
        }
    
        // Using a DependencyProperty as the backing store for DoubleClickCommand.  This enables animation, styling, binding, etc... 
        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommand", typeof(ICommand), typeof(Attached), new UIPropertyMetadata(null, CommandChanged));
        public static readonly DependencyProperty DoubleClickCommandParameterProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommandParameter", typeof(object), typeof(Attached));
    
        static void CommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var fe = obj as FrameworkElement;
            if (e.OldValue == null && e.NewValue != null)
            {
                fe.AddHandler(Button.MouseDoubleClickEvent, ExecuteCommand);
            }
            else if (e.OldValue != null && e.NewValue == null)
            {
                fe.RemoveHandler(Button.MouseDoubleClickEvent, ExecuteCommand);
            }
        }
    
        static void ExecuteCommand(object sender, RoutedEventArgs e)
        {
            var ele = sender as Button;
            ICommand command = GetDoubleClickCommand(ele);
            object parameter = GetDoubleClickCommandParameter(ele);
            command.Execute(parameter);
        }
    }
