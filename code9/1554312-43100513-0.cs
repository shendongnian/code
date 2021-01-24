    public T GetRegData<T>(string v)
    {
        RegistryKey key = registryPointer();
        object oValue;
        if ( typeof(T) == typeof(string) )
        {
            oValue = key.GetValue(v, "");
        }
        else if (typeof(T) == typeof(int))
        {
            oValue = key.GetValue(v, 0);
        }
        else if (typeof(T) == typeof(bool))
        {
            oValue = key.GetValue(v, false);
        }
        else
        {
            oValue = key.GetValue(v, null);
        }
        ...
    }
