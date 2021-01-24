    public class TestProperties {
        public static readonly DependencyProperty TestProperty = DependencyProperty.Register(
            "Test",
            typeof(Boolean),
            typeof(TestProperties)
        );
        public static void SetTest(UIElement element, Boolean value) {
            element.SetValue(TestProperty, value);
        }
        public static Boolean GetTest(UIElement element) {
            return (Boolean) element.GetValue(TestProperty);
        }
    }
