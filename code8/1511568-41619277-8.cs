    public class MyBehavior
    {
        public static object GetView(DependencyObject obj) => obj.GetValue(ViewProperty);
        public static void SetView(DependencyObject obj, object value) => obj.SetValue(ViewProperty, value);
        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.RegisterAttached("View", typeof(object), typeof(MyBehavior), 
                new PropertyMetadata(/*default value: */ null, new PropertyChangedCallback(OnPropertyChanged)));
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element == null)
                throw new ArgumentException("Only used with FrameworkElement");
            element.Loaded += (s, a) => 
            {
                string propertyName = GetView(element).ToString();
                if(element.DataContext != null)
                {
                    System.Reflection.PropertyInfo pi = element.DataContext.GetType().GetProperty(propertyName);
                    pi.SetValue(element.DataContext, "new value...");
                }
            };
        }
    }
