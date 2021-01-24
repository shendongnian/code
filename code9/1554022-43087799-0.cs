    public class TextBlockBehavior
    {
        public static bool GetMyProperty(DependencyObject obj) => (bool)obj.GetValue(MyPropertyProperty);
        public static void SetMyProperty(DependencyObject obj, bool value) => obj.SetValue(MyPropertyProperty, value);
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.RegisterAttached("MyProperty", typeof(bool), typeof(TextBlockBehavior), new PropertyMetadata(false));
    }
