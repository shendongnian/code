    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
        var asmName = new AssemblyName(args.Name);
        var existing = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(c => c.GetName() == asmName);
        if (existing != null) {
            return existing;
        }
        return null;
    };
