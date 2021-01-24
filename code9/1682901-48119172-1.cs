     public class AttachedProperty
    {
        public static readonly DependencyProperty AltSourceProperty =
            DependencyProperty.RegisterAttached("AltSource",
            typeof(string), typeof(AttachedProperty),
            new PropertyMetadata());
        public static string GetAltSource(DependencyObject obj)
        {
            return (string)obj.GetValue(AltSourceProperty);
        }
        public static void SetAltSource(DependencyObject obj, string value)
        {
            obj.SetValue(AltSourceProperty, value);
        }
    }
