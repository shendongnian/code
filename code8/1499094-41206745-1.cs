    public static T CreateNeed<T>(IConvertable ToConvert) where T : IConvertable, new()
    {
        T Need = new T();
        Need.id = ToConvert.id;
        Need.name = ToConvert.name;
        //...
        return Need;
    }
