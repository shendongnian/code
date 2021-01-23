    public static class Factory
    {
        static Dictionary<string, Type> _fac = new Dictionary<string, Type>();
    
        public static void Assign<T>(string key)
        {
            if(_fac.ContainsKey(key))
            {
                if(_fac[key] != typeof(T)) _fac[key] = typeof(T);
            }
            else 
            {
                _fac.Add(key, typeof(T));
            }
        }
        public static object Retrieve(string key, string value)
        {
            if(_fac.ContainsKey(key))
            {
                if(_fac[key] == typeof(string))
                    return value;
                TypeConverter converter = TypeDescriptor.GetConverter(_fac[key]);
                if(converter.CanConvertFrom(typeof(string))
                    return converter.ConvertFromString(value);
            }
            return null;
        }
        public static Type TypeFor(string key)
        {
            if(_fac.ContainsKey(key))
                return _fac[key];
            return null;
        }
    }
