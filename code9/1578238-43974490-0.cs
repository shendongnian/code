    namespace YourNamespace
    {
        public static class CloseConfirmation
        {
            public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
               "IsActive",
               typeof(bool),
               typeof(CloseConfirmation));
            public static bool GetIsActive(DependencyObject obj)
            {
                return (bool)obj.GetValue(HiddenProperty);
            }
            public static void SetIsActive(DependencyObject obj, bool value)
            {
                obj.SetValue(HiddenProperty, value);
            }
        }
    }
