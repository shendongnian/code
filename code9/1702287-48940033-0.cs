    static void Main(string[] args)
    {
        Type runtimeType = typeof(string);
        object genType = Activator.CreateInstance(typeof(MyGenericType<>).MakeGenericType(runtimeType));
        var genericMethod = ((Action<MyGenericType<object>>)CallMethod)
            .Method
            .GetGenericMethodDefinition()
            .MakeGenericMethod(runtimeType)
            .Invoke(null, new object[] { genType });
    }
    static void CallMethod<T>(MyGenericType<T> myGeneric)
    {
        MyEnumerableMethod((IEnumerable<T>)myGeneric);
    }
