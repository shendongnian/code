    public static Version GetAssemblyVersion(this FileInfo fi)
    {
        AssemblyName an = AssemblyName.GetAssemblyName(fi.FullName);
        return an.Version;
    }
