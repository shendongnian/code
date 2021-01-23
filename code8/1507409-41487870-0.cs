    public class DynamicBinding
    {
        public static object GetSource(DependencyObject obj) => (object)obj.GetValue(SourceProperty);
        public static void SetSource(DependencyObject obj, object value) => obj.SetValue(SourceProperty, value);
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached("Source", typeof(object), typeof(DynamicBinding), new PropertyMetadata(null, (d, e) => SetBinding(d)));
        public static string GetProperty(DependencyObject obj) => (string)obj.GetValue(PropertyProperty);
        public static void SetProperty(DependencyObject obj, string value) => obj.SetValue(PropertyProperty, value);
        public static readonly DependencyProperty PropertyProperty =
            DependencyProperty.RegisterAttached("Property", typeof(string), typeof(DynamicBinding), new PropertyMetadata(null, (d, e) => SetBinding(d)));
        public static string GetTarget(DependencyObject obj) => (string)obj.GetValue(TargetProperty);
        public static void SetTarget(DependencyObject obj, string value) => obj.SetValue(TargetProperty, value);
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.RegisterAttached("Target", typeof(string), typeof(DynamicBinding), new PropertyMetadata(null, (d, e) => SetBinding(d)));
        static void SetBinding(DependencyObject obj)
        {
            var source = GetSource(obj);
            var property = GetProperty(obj);
            var target = GetTarget(obj);
            // only if all required attached properties values are set
            if (source == null || property == null || target == null)
                return;
            BindingOperations.SetBinding(obj, DependencyPropertyDescriptor.FromName(target, obj.GetType(), obj.GetType()).DependencyProperty,
                new Binding(property) { Source = source });
        }
    }
