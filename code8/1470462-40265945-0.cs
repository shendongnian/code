    public static void Main(string[] args)
    {
        Set(new TestClass());
    }
    public static void Set(object objectToCache)
    {
        var result = objectToCache.GetType().GetCustomAttributes(false)
                                            .Any(att => att is ProtoContractAttribute);
        // Or other overload:
        var result2 = objectToCache.GetType().GetCustomAttributes(typeof(ProtoContractAttribute), false).Any();
        // result - true   
     }
