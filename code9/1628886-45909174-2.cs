    public static class Alt
    {
        #region Background
        public static readonly DependencyProperty BackgroundProperty =
                  DependencyProperty.RegisterAttached("Background", typeof(Brush),
                  typeof(Alt), new PropertyMetadata(null));
    
        public static Brush GetBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(Alt.BackgroundProperty);
        }
    
        public static void SetBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(Alt.BackgroundProperty, value);
        }
        #endregion
    }
