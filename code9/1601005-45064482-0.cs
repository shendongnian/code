    private async Task<IEnumerable<Assembly>> GetAssemblyListAsync()
    {
       var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            
       List<Assembly> assemblies = new List<Assembly>();
       foreach (Windows.Storage.StorageFile file in await folder.GetFilesAsync())
       {
            if (file.FileType == ".dll" || file.FileType == ".exe")
            {
               AssemblyName name = new AssemblyName() { 
                                             Name = Path.GetFileNameWithoutExtension(file.Name) };
               Assembly asm = Assembly.Load(name);
               assemblies.Add(asm);
            }
       }
            
       return assemblies;
    }
