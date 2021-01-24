    void LoadInstaller(Type type, IServiceCollection services)
    {
        var installMethods= type.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(mi => mi.Name == "Install");
        var installMethod = installMethods.First();
        installMethod.Invoke(null, new object[] { services });
    }
