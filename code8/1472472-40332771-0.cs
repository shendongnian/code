    public class ToggleButtonImage
    {
        public static readonly DependencyProperty ToggleButtonImageSourceProperty =
            DependencyProperty.RegisterAttached(
                "ToggleButtonImageSource", typeof(string), typeof(ToggleButtonImage));
        public static void SetToggleButtonImageSource(UIElement element, string value)
        {
            element.SetValue(ToggleButtonImageSourceProperty, value);
        }
        public static string GetToggleButtonImageSource(UIElement element)
        {
            return (string)element.GetValue(ToggleButtonImageSourceProperty);
        }
    }
