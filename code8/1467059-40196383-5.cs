    public static Version GetAssemblyVersion(this FileInfo fi)
    {
      AppDomain checkFileDomain = AppDomain.CreateDomain("DomainToCheckFileVersion");
      Assembly assembly = checkFileDomain.Load(new AssemblyName {CodeBase = fi.FullName});
      Version fileVersion = assembly.GetName().Version;
      AppDomain.Unload(checkFileDomain);
      return fileVersion;
    }
