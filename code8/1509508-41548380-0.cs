    public static class Factory
    {
        Dictionary<string, Type> _fac = new Dictionary<string, Type>();
    
        public static void Assign<T>(string key)
        {
            if(_fac.Contains(key))
            {
                if(_fac[key] != typeof(T)) _fac[key] = typeof(T);
            }
            else 
            {
                _fac.Add(key, typeof(T));
            }
        }
        public object Retrieve(string key, string value)
        {
            if(_fac.ContainsKey(key))
            {
                TypeConverter converter = TypeDescriptor.GetConverter(_fac[key]);
                if(converter.CanConvertFrom(typeof(string))
                    return converter.ConvertFromString(value);
            }
            return null;
        }
    }
