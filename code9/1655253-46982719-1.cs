    public static IHSM GetInstance(string configPath)
    {
        // for now, there's only one
        Type t = GetImplements(typeof(IHSM)).FirstOrDefault();
        ConstructorInfo ctor = t.GetConstructor(new Type[] { typeof(string) });// assume empty constructor
        return ctor.Invoke(new object[] { configPath }) as IHSM;
    }
