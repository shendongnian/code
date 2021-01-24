    protected List<Assembly> _assemblies = new List<Assembly>(); 
    public List<Type> FilterByType<T>()
    {
        return this._assemblies.SelectMany(x => x.GetTypes()).Where(type => typeof (T).IsAssignableFrom(type)).ToList();
    }
    public List<Type> FilterByType(Type BaseType)
    {
        return this._assemblies.SelectMany(x => x.GetTypes()).Where(type => BaseType.IsAssignableFrom(type)).ToList();
    }
