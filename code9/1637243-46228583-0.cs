    public static class ListBoxItemAttachedProperties
    {
        public static bool GetIsMouseDown(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMouseDownProperty);
        }
        public static void SetIsMouseDown(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMouseDownProperty, value);
        }
        public static readonly DependencyProperty IsMouseDownProperty =
            DependencyProperty.RegisterAttached("IsMouseDown", typeof(bool), typeof(UIElementAttachedProperties), new PropertyMetadata(false));
    }
