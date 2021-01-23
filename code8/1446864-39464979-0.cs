    public class ExtendedAssemblyResolver : DefaultAssembliesResolver
    {
        private string[] dynamicAssemblies;
    
        public ExtendedAssemblyResolver(string[] dynamicAssemblies)
        {
            System.Diagnostics.Debugger.Launch();
            this.dynamicAssemblies = dynamicAssemblies;
        }
    
        public override ICollection<Assembly> GetAssemblies()
        {
            var baseAssemblies = base.GetAssemblies();
            var assemblies = new List<Assembly>(baseAssemblies);
    
            if (dynamicAssemblies != null)
            {
                foreach (var asm in dynamicAssemblies)
                {
                    var controllersAssembly = Assembly.LoadFrom(asm);
                    baseAssemblies.Add(controllersAssembly);
                }
            }
    
            return baseAssemblies;
        }
    }
