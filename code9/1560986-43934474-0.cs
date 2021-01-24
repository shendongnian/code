    public static class AnimateableVisibility
    {
        public static readonly DependencyProperty VisibilityProperty = DependencyProperty.RegisterAttached(
            "Visibility", typeof(Visibility), typeof(AnimateableVisibility), new PropertyMetadata(default(Visibility), VisibilityPropertyChanged));
        private static void VisibilityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var val = (Visibility) e.NewValue;
            // Set StartVisibility to Visible when Visibility is set to Visible
            if (val == Visibility.Visible) 
                d.SetCurrentValue(StartVisibilityProperty, val);
        }
        public static readonly DependencyProperty StartVisibilityProperty = DependencyProperty.RegisterAttached(
            "StartVisibility", typeof(Visibility), typeof(AnimateableVisibility), new PropertyMetadata(default(Visibility)));
        public static Visibility GetVisibility(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(VisibilityProperty);
        }
        
        public static void SetVisibility(DependencyObject obj, Visibility value)
        {
            obj.SetValue(VisibilityProperty, value);
        }
        public static Visibility GetStartVisibility(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(VisibilityProperty);
        }
        public static void SetStartVisibility(DependencyObject obj, Visibility value)
        {
            obj.SetValue(VisibilityProperty, value);
        }
    }
