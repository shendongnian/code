        public static class IsSelectTextExtension
        {
        public static readonly DependencyProperty IsSelectTextProperty = DependencyProperty.RegisterAttached("IsSelectText", typeof(bool), typeof(IsSelectTextExtension), new UIPropertyMetadata(false, OnIsSelectTextPropertyChanged));
        public static bool GetIsSelectText(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSelectTextProperty);
        }
        public static void SetIsSelectText(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSelectTextProperty, value);
        }
        private static void OnIsSelectTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uie = (TextBox)d;
            if ((bool)e.NewValue)
            {
                uie.SelectAll();
            }
        }
        }
