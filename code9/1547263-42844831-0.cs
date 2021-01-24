    public sealed class Manager
        {
            //prevents the default instance from being instantiated
            private Manager() { }
    
            public static IFoo GetMyIFoo(IParam param)
            {
    
                Factory factory = new Factory();
                return factory.GetMyIFoo(param);
            }
        }
