    namespace WpfApplication1
    {
        public class SharedProperties
        {
            public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
                "IsEnabled",
                typeof(bool),
                typeof(SharedProperties),
                new FrameworkPropertyMetadata(false));
            public static void SetIsEnabled(UIElement element, bool value)
            {
                element.SetValue(IsEnabledProperty, value);
            }
            public static bool GetIsEnabled(UIElement element)
            {
                return (bool)element.GetValue(IsEnabledProperty);
            }
        }
    }
