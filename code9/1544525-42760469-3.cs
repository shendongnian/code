    public class TestProperties : DependencyObject { // must inherit dependency object
        public static readonly DependencyProperty TestProperty = DependencyProperty.Register(
            "Test",
            typeof(Boolean),
            typeof(TestProperties),
            new PropertyMetadata(true, OnTestChanged)
        );
        private static void OnTestChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            // this will be called ONLY when we do something like 
            // var prop = new TestProperties();
            // prop.SetValue(TestProperty, true);
            // but will NOT be called when we set value for TextBlock
        }
        public static void SetTest(UIElement element, Boolean value) {
            element.SetValue(TestProperty, value);
        }
        public static Boolean GetTest(UIElement element) {
            return (Boolean) element.GetValue(TestProperty);
        }
    }
