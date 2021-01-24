    public ConnectionProvider()
    {
        ResourceManager rm = new ResourceManager("Bank.Project.API.resources", GetAssemblyByName("Bank.Project.API"));
        this.connectionString = rm.GetString(Connection.Name);
        this.factory = DbProviderFactories.GetFactory(rm.GetString(Connection.Factory));
    }
    Assembly GetAssemblyByName(string name)
    {
        var Myassembly = AppDomain.CurrentDomain.GetAssemblies().
               SingleOrDefault(assembly => assembly.GetName().Name == name);
        return Myassembly;
    }
