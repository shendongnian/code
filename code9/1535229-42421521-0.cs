    public class ButtonProperties
    {
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.RegisterAttached("ImageSource", typeof(Uri), typeof(ButtonProperties));
        public static Uri GetImageSource(Button button)
        {
            return (Uri)button.GetValue(ImageSourceProperty);
        }
        public static void SetImageSource(Button button, Uri value)
        {
            button.SetValue(ImageSourceProperty, value);
        }
        public static readonly DependencyProperty TextProperty = 
            DependencyProperty.RegisterAttached("Text", typeof(Uri), typeof(ButtonProperties));
        public static string GetText(Button button)
        {
            return (string)button.GetValue(ImageSourceProperty);
        }
        public static void SetText(Button button, string value)
        {
            button.SetValue(ImageSourceProperty, value);
        }
    }
