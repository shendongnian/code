    public static class SquareSize
    {
        public static double GetWidthLimit(DependencyObject obj)
        {
            return (double)obj.GetValue(WidthLimitProperty);
        }
        public static void SetWidthLimit(DependencyObject obj, double value)
        {
            obj.SetValue(WidthLimitProperty, value);
        }
        public static readonly DependencyProperty WidthLimitProperty = DependencyProperty.RegisterAttached(
            "WidthLimit", typeof(double), typeof(SquareSize),
            new FrameworkPropertyMetadata(double.PositiveInfinity, new PropertyChangedCallback(OnWidthLimitChanged)));
        private static void OnWidthLimitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateSize(d, (double)e.NewValue, GetHeightLimit(d));
        }
        public static double GetHeightLimit(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightLimitProperty);
        }
        public static void SetHeightLimit(DependencyObject obj, double value)
        {
            obj.SetValue(HeightLimitProperty, value);
        }
        public static readonly DependencyProperty HeightLimitProperty = DependencyProperty.RegisterAttached(
            "HeightLimit", typeof(double), typeof(SquareSize),
            new FrameworkPropertyMetadata(double.PositiveInfinity, new PropertyChangedCallback(OnHeightLimitChanged)));
        private static void OnHeightLimitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateSize(d, GetWidthLimit(d), (double)e.NewValue);
        }
        private static void UpdateSize(DependencyObject d, double widthLimit, double heightLimit)
        {
            double resultSize = Math.Min(widthLimit, heightLimit);
            d.SetCurrentValue(FrameworkElement.WidthProperty, resultSize);
            d.SetCurrentValue(FrameworkElement.HeightProperty, resultSize);
        }
    }
