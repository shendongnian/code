    public class Helper
    {
        public static bool GetUseWindowCommandBindings(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseWindowCommandBindingsProperty);
        }
        public static void SetUseWindowCommandBindings(DependencyObject obj, bool value)
        {
            obj.SetValue(UseWindowCommandBindingsProperty, value);
        }
        public static readonly DependencyProperty UseWindowCommandBindingsProperty =
            DependencyProperty.RegisterAttached("UseWindowCommandBindings", typeof(bool), typeof(Helper), new PropertyMetadata(false, UseWindowCommandBindingsChanged));
        private static void UseWindowCommandBindingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs dpce)
        {
            if (d is Window w && dpce.NewValue is bool b && b)
            {
                w.CommandBindings.Add(
                    new CommandBinding(
                        SystemCommands.MinimizeWindowCommand,
                        (s, e) => SystemCommands.MinimizeWindow(w),
                        (s, e) => e.CanExecute = true
                        ));
                w.CommandBindings.Add(
                    new CommandBinding(
                        SystemCommands.RestoreWindowCommand,
                        (s, e) => SystemCommands.RestoreWindow(w),
                        (s, e) => e.CanExecute = true
                        ));
                w.CommandBindings.Add(
                    new CommandBinding(
                        SystemCommands.MaximizeWindowCommand,
                        (s, e) => SystemCommands.MaximizeWindow(w),
                        (s, e) => e.CanExecute = true
                        ));
                w.CommandBindings.Add(
                    new CommandBinding(
                        SystemCommands.CloseWindowCommand,
                        (s, e) => SystemCommands.CloseWindow(w),
                        (s, e) => e.CanExecute = true
                        ));
            }
        }
    }
