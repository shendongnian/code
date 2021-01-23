    <TextBlock local:MyBehavior.View="{Binding A}" />
----------
    public class MyBehavior
    {
        public static object GetView(DependencyObject obj) => obj.GetValue(ViewProperty);
        public static void SetView(DependencyObject obj, object value) => obj.SetValue(ViewProperty, value);
        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.RegisterAttached("View", typeof(object), typeof(MyBehavior), 
                new PropertyMetadata(/*default value: */ null, new PropertyChangedCallback(OnPropertyChanged)));
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            object theValue = GetView(d);
            MessageBox.Show(theValue.ToString());
        }
    }
