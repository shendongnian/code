    public static class FrameworkElementExtension
    {
        public static readonly DependencyProperty TargetWidthProperty =
            DependencyProperty.RegisterAttached(
                "TargetWidth",
                typeof(double),
                typeof(FrameworkElementExtension),
                new PropertyMetadata(TargetWidthPropertyChanged));
        public static double GetTargetWidth(this FrameworkElement obj)
        {
            return (double)obj.GetValue(TargetWidthProperty);
        }
        public static void SetTargetWidth(this FrameworkElement obj, double value)
        {
            obj.SetValue(TargetWidthProperty, value);
        }
        private static void TargetWidthPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var element = obj as FrameworkElement;
            if (element != null)
            {
                element.BeginAnimation(
                    FrameworkElement.WidthProperty,
                    new DoubleAnimation((double)e.NewValue, TimeSpan.FromSeconds(0.2)));
            }
        }
    }
