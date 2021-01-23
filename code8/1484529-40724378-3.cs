    public class MyClass<T> : Control where T : struct
    {
        public T Value
        {
            get { return (T)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        // DependencyProperty as the backing store for Value
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(T),
            typeof(MyClass<T>),
            new PropertyMetadata(default(T), null, CoerceValue) //Must pass default(T) otherwise an exception will occur.
        );
        private static object CoerceValue(DependencyObject d, object baseValue)
        {
            var tValue = (T)baseValue;
            // Check if tValue is valid 
            return tValue;
        }
    }
