    public static class PanelItems
    {
        public static readonly DependencyProperty MarginProperty =
            DependencyProperty.RegisterAttached(
                "Margin", typeof(Thickness), typeof(PanelItems),
                new FrameworkPropertyMetadata(new Thickness(),
                    FrameworkPropertyMetadataOptions.Inherits, MarginChangedCallback));
        public static Thickness GetMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(MarginProperty);
        }
        public static void SetMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(MarginProperty, value);
        }
        public static void MarginChangedCallback(
            object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element != null && !(element is Panel))
            {
                element.Margin = (Thickness)e.NewValue;
            }
        }
    }
 
