    public class MyLibraryConfig
    {
        public readonly string AssemblyName;
        public MyLibraryConfig(string assemblyName) { 
            this.AssemblyName = assemblyName;
        }
    }
    public class MyLibrary : IMyLibrary
    {
        public MyLibrary(MyLibraryConfig config, IOtherDependency dep) { ... }
    }
