    public static T ParseFromA<T>(string filename) where T : Parent, new()
    {
        T t = new T();
        // parse file and set property here...
        return t;
    }
