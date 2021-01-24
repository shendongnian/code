    public static IEnumerable<Assembly> GetClientAssembliesRelativeToAssembly(Assembly asm, string subPath = null, string wildcard = "Sdi*.dll")
    {
        var path = subPath != null
            ? Path.Combine(Path.GetDirectoryName(asm.CodeBase.Substring(8)), subPath)
            : Path.GetDirectoryName(asm.CodeBase.Substring(8));
        foreach (var dll in Directory.GetFiles(path, wildcard))
        {
            yield return Assembly.LoadFile(dll);
        }
    }
