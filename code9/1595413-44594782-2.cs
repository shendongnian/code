    [Serializable]
    public class RemoteValueConfigBase<T>
    {
        public string Key;
        public T DefaultValue;
        public RemoteValueConfigBase(string key, T defaultValue)
        {
            Key = key;
            DefaultValue = defaultValue;
        }
    }
    [Serializable]
    public class RemoteValueConfigStr : RemoteValueConfigBase<string>
    {
        public RemoteValueConfigStr(string key, string defaultValue) : base(key, defaultValue)
        { }
    }
    [Serializable]
    public class RemoteValueConfigBool : RemoteValueConfigBase<bool>
    {
        public RemoteValueConfigBool(string key, bool defaultValue) : base(key, defaultValue)
        { }
    }
    [Serializable]
    public class RemoteValueConfigInt : RemoteValueConfigBase<int>
    {
        public RemoteValueConfigInt(string key, int defaultValue) : base(key, defaultValue)
        { }
    }
    [Serializable]
    public class RemoteValueConfigDouble : RemoteValueConfigBase<double>
    {
        public RemoteValueConfigDouble(string key, double defaultValue) : base(key, defaultValue)
        { }
    }
    ...etc
