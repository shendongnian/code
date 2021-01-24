    public static class ToggleButtonExtensions
    {
        public static readonly DependencyProperty CanNotUncheckByHandProperty = DependencyProperty.RegisterAttached(
            "CanNotUncheckByHand", typeof(bool), typeof(ToggleButtonExtensions), new PropertyMetadata(default(bool), OnCanNotUncheckByHandPropertyChangedCallback));
        private static void OnCanNotUncheckByHandPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (!(dependencyObject is ToggleButton)) return;
            if ((bool)eventArgs.NewValue)
                ((ToggleButton)dependencyObject).Click += OnClick;
            else
                ((ToggleButton)dependencyObject).Click -= OnClick;
        }
        public static void SetCanNotUncheckByHand(DependencyObject element, bool value)
        {
            element.SetValue(CanNotUncheckByHandProperty, value);
        }
        private static void OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            ((ToggleButton) sender).IsChecked = true;
        }
        public static bool GetCanNotUncheckByHand(DependencyObject element)
        {
            return (bool) element.GetValue(CanNotUncheckByHandProperty);
        }
    }
