    public T Vehicle<T>(T it) {
        try {
            Type type = it.GetType();                                   // read  incoming Vehicle type
            ConstructorInfo ctor = type.GetConstructor(new[] { type }); // get its constructor
            object instance = ctor.Invoke(new object[] { it });         // invoke its constructor
            return (T)instance;                                         // return proper vehicle type
        } catch { return default(T); }
    }
