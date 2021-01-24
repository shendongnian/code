    class SomeGenericType<T>
    {
        static SomeGenericType()
        {
            Program.RegisterClosedType(typeof(SomeGenericType<T>));    
        }
    }
