    public static class TupleExtensions
    {
        private static readonly HashSet<Type> ValueTupleTypes = new HashSet<Type>(new Type[]
        {
            typeof(ValueTuple<>),
            typeof(ValueTuple<,>),
            typeof(ValueTuple<,,>),
            typeof(ValueTuple<,,,>),
            typeof(ValueTuple<,,,,>),
            typeof(ValueTuple<,,,,,>),
            typeof(ValueTuple<,,,,,,>),
            typeof(ValueTuple<,,,,,,,>)
        });
        public static bool IsValueTuple(this object obj)
        {
            var type = obj.GetType();
            return type.GetTypeInfo().IsGenericType && ValueTupleTypes.Contains(type.GetGenericTypeDefinition());
        }
    
        public static List<object> GetValueTupleItems(this object tuple)
        {
            var items = new List<object>();
    
            try
            {
                items.Add(((dynamic)tuple).Item1);
                items.Add(((dynamic)tuple).Item2);
                items.Add(((dynamic)tuple).Item3);
                items.Add(((dynamic)tuple).Item4);
                items.Add(((dynamic)tuple).Item5);
                items.Add(((dynamic)tuple).Item6);
                items.Add(((dynamic)tuple).Item7);
                items.Add(((dynamic)tuple).Item8);
            }
            catch (RuntimeBinderException) { }
    
            return items;
        }
    }
