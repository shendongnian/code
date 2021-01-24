    public static class Animated
    {
        private static Duration duration = TimeSpan.FromSeconds(5);
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached(
                "Height", typeof(double), typeof(Animated),
                new PropertyMetadata(HeightPropertyChanged));
        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }
        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }
        private static void HeightPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var element = obj as FrameworkElement;
            if (element != null)
            {
                var to = (double)e.NewValue;
                var animation = double.IsNaN(element.Height)
                    ? new DoubleAnimation(0, to, duration)
                    : new DoubleAnimation(to, duration);
                element.BeginAnimation(FrameworkElement.HeightProperty, animation);
            }
        }
    }
