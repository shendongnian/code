    public static void Registration()
    {
        List<RegistryAttribute> atrr = new List<RegistryAttribute>();
    
        var assembly = System.Reflection.Assembly.GetCallingAssembly();
    
        var types = assembly.GetTypes().Where(type => 
                        type.GetCustomAttributes().Any(x => x is typeof(MyCustomAttribute))).ToList();
    }
