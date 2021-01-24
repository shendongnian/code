    [Serializable]
    class T
    {
        public int F1 { get; set; }
        public int F2 { get; set; }
    }
    T CloneT(T obj)
    {
        var ms = new MemoryStream();
        var formatter = new BinaryFormatter();
        formatter.Serialize(ms, o);
        ms.Position = 0;
        var clone = (T)formatter.Deserialize(ms);
        return clone;
    }
    var o = new T { F1 = 5, F2 = 12 };
    CloneT(o);
