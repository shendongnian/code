    public static class FocusAdvancement
    {
        public static readonly DependencyProperty ValidationOnLostFocusProperty=
            DependencyProperty.RegisterAttached ("ValidationOnLostFocus",typeof (bool),typeof (FocusAdvancement),new UIPropertyMetadata (OnValidationOnLostFocusPropertyChanged));
        public static bool GetValidationOnLostFocusProperty(DependencyObject d)
        {
            return (bool)d.GetValue (ValidationOnLostFocusProperty);
        }
        public static void SetValidationOnLostFocusProperty(DependencyObject d,bool value)
        {
            d.SetValue (ValidationOnLostFocusProperty,value);
        }
        private static void OnValidationOnLostFocusPropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            var element=(UIElement)d;
            if (element==null)
                return;
            if ((bool)e.NewValue)
            {
                element.LostFocus+=LostFocus;
            }
            else
                element.GotFocus-=LostFocus;
        }
        private static void LostFocus(object sender,RoutedEventArgs e)
        {
            var element=(UIElement)sender;
            if (element!=null)
            {
                TextBox oTextBox=(TextBox)element;
                oTextBox.GetBindingExpression (TextBox.TextProperty).UpdateSource ();
            }
        }
