     public static class Repository
        {
            private static Dictionary<Type, object> _dictionary;
            static Repository()
            {
               _dictionary=new Dictionary<Type, object>(); 
            }
    
            public static T ReadRepository<T>()
            {
                var type = typeof (T);
                object item;
                var result = _dictionary.TryGetValue(type, out item);
                if (!result) return default (T);
                return (T)Convert.ChangeType(item, typeof(T));
            }
    
            public static void InjectRepository<T>(object value)
            {
                var type = typeof(T);
                object item;
                var result = _dictionary.TryGetValue(type, out item);
                if(result)return;
                _dictionary.Add(type, value);
            }
    
        }
