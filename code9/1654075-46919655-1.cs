    public Assembly Resolve(object sender, ResolveEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("AssemblyResolve event for: {0}\t\tRequestingAssembly {1}", e.Name, e.RequestingAssembly);
        switch(e.Name)
        {
            case "EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=aed0ab2de30e5e00":
                return LoadAssembly(e);
            case "System.Data.SQLite.EF6, Version=1.0.102.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139":
                return LoadAssembly(e);
            case "BlueTechZone.Sqlite.EF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7741556173e269b9":
                string codeBase = CodeBase + _SubDirectory + "System.Data.SQLite.EF6.dll";
                var ef6SQLite = Assembly.LoadFrom(codeBase);
                return LoadAssembly(e, new String[] { "SQLite.Interop.dll" });
            case "System.Data.SQLite, Version=1.0.102.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139":
                return LoadAssembly(e, new String[] { "SQLite.Interop.dll" });
            default:
                return null;
        }
    }
