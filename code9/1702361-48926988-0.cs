        public static IEnumerable<Type> GetTypes()
        {
            var sourceAssembly = Assembly.GetCallingAssembly();
            var assemblies = new List<Assembly>();
            assemblies.AddRange(sourceAssembly.GetReferencedAssemblies().Select(an => Assembly.Load(an)));
            assemblies.Add(sourceAssembly);
            var subclassTypes = new HashSet<Type>();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AbstractMyGameBeh)));
                foreach (var type in types) subclassTypes.Add(type);
            }
            return subclassTypes;
        }
