    //using System.Reflection;
    public static TValue GetOrCreateEntry<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key)
    {
        TValue value;
        if (!dict.TryGetValue(key, out value))
        {
            // not in dictionary
            ConstructorInfo ctor = typeof(TValue).GetConstructor(new Type[] { typeof(TKey) });
            if (ctor != null)
            {
                // we have a constructor that matches the type you need
                value = (TValue)ctor.Invoke(new object[] { key });
                dict[key] = value;
                return value;
            }
            else
                throw new NotImplementedException(); // because the TValue type does not implement the constructor you anticipate
        }
    
        // we got it from dictionary, so just return it
        return value;
    }
