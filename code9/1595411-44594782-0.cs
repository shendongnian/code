    [Serializable]
    public struct RemoteValueConfigBase<T> {
        public string Key;
        public T DefaultValue;
        public RemoteValueConfigBase(string key, T defaultValue)
        {
            Key = key;
            DefaultValue = defaultValue;
        }
    }
    [Serializable]
    public struct RemoteValueConfigStr : RemoteValueConfigBase<string>
    { }
    [Serializable]
    public struct RemoteValueConfigBool : RemoteValueConfigBase<bool>
    { }
    [Serializable]
    public struct RemoteValueConfigInt : RemoteValueConfigBase<int>
    { }
    [Serializable]
    public struct RemoteValueConfigDouble : RemoteValueConfigBase<double>
    { }
    ...etc
