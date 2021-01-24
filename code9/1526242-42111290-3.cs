    public class GlobalManager
    {
        static object _LockObject_GFS = new object();
        static double _GlobalFontSize;
        public static double GlobalFontSize
        {
            get
            {
                lock (_LockObject_GFS)
                {
                    return _GlobalFontSize;
                }
            }
            set
            {
                lock (_LockObject_GFS)
                {
                    if (_GlobalFontSize != value)
                    {
                        _GlobalFontSize = value;
                        NotifyStaticPropertyChanged(()=> GlobalFontSize);
                    }
                }
            }
        }
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        public static void NotifyStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        public static void NotifyStaticPropertyChanged<T>(Expression<Func<T>> property)
        {
            var expr = property.Body as MemberExpression;
            if (expr == null)
                throw new ArgumentException("Lambda does not contain member expression. () => MyClassOrObject.Property");
            NotifyStaticPropertyChanged(expr.Member.Name);
        }
    }
