    public class TestProperties {
        public static readonly DependencyProperty TestProperty = DependencyProperty.RegisterAttached(
            "Test",
            typeof(Boolean),
            typeof(TestProperties),
            new PropertyMetadata(true, OnTestChanged)
        );
        private static void OnTestChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            
        }
        public static void SetTest(UIElement element, Boolean value) {
            element.SetValue(TestProperty, value);
        }
        public static Boolean GetTest(UIElement element) {
            return (Boolean) element.GetValue(TestProperty);
        }
    }
