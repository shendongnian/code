    public static class TestingProperties
    {
        private static readonly Dictionary<string, int> _counter = new Dictionary<string, int>();
        public static readonly DependencyProperty AutoNameProperty = DependencyProperty.RegisterAttached(
            "AutoName", typeof(string), typeof(TestingProperties), new PropertyMetadata(default(string), OnAutoNamePropertyChanged));
        private static void OnAutoNamePropertyChanged(DependencyObject element, DependencyPropertyChangedEventArgs eventArgs)
        {
            string value = (string) eventArgs.NewValue;
            if (String.IsNullOrWhiteSpace(value)) return;
            if (DesignerProperties.GetIsInDesignMode(element)) return;
            if (!(element is FrameworkElement)) return;
            
            int index = 0;
            if (!_counter.ContainsKey(value))
                _counter.Add(value, index);
            else
                index = ++_counter[value];
            string name = String.Format("{0}_{1}", value, index);
            ((FrameworkElement)element).Name = name;
            ((FrameworkElement)element).RegisterName(name, element);
        }
        public static void SetAutoName(DependencyObject element, string value)
        {
            element.SetValue(AutoNameProperty, value);
        }
        public static string GetAutoName(DependencyObject element)
        {
            return (string)element.GetValue(AutoNameProperty);
        }
    }
