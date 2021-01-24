    public static TOutput DoWork()
    {
        var generic = new GenericType<TOutput>();
        var ret = generic.MethodName();
        return ret;
    }
