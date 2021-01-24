    public static string ProcessModel(ISomeInterface model)
    {
        return model.calc("100");
    }
    //OR
    public static string ProcessModel(object model)
    {
        return CallMethodOfSomeObject(model, "calc", "100");
    }
