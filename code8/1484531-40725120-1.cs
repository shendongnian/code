    public abstract class MyClass<T> : Control where T : struct
    {
        ...
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(T), typeof(MyClass<T>),
            new PropertyMetadata(default(T), null, CoerceValue));
        protected abstract T CoerceValue(T value);
        private static object CoerceValue(DependencyObject d, object value)
        {
            return ((MyClass<T>)d).CoerceValue((T)value);
        }
    }
    public class MyDerivedClass : MyClass<int>
    {
        protected override int CoerceValue(int value)
        {
            return Math.Max(100, Math.Min(200, value));
        }
    }
