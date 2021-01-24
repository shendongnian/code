    class ClassA
    {
        static void Main(string[] args)
        {
            // specify here the projects needed to resolve your types
            var projects = new List&lt;string&gt; { "ProjectB", "ProjectC", "ProjectD" };
            var types = GetAllTypes(projects);
            var interfaces = types.Where(t => t.IsInterface).ToList();
            // init autofac container builder
            var builder = new ContainerBuilder();
            // add types to the builder
            foreach (var interfaceType in interfaces)
            {
                var implementingType = types.FirstOrDefault(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface);
                if (implementingType != null)
                {
                    builder.RegisterType(implementingType).As(interfaceType);
                }
            }
            var container = builder.Build();
            // test ClassB and ClassC can be instantiated through their interface
            using (var scope = container.BeginLifetimeScope())
            {
                var classB = scope.Resolve&lt;IClassB&gt;();
                var classC = scope.Resolve&lt;IClassC&gt;();
            }
        }
        // get all the classes and interfaces from the selected projects
        private static List&lt;Type&gt; GetAllTypes(List&lt;string&gt; projects) =>
            Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory)
                .Where(f => f.ToLower().EndsWith(".dll"))
                .Where(f => projects.Any(a => Assembly.ReflectionOnlyLoadFrom(f).GetName().Name.StartsWith(a)))
                .Select(a => Assembly.ReflectionOnlyLoadFrom(a).FullName)
                .Select(Assembly.Load)
                .SelectMany(a => a.GetTypes())
                .ToList();
    }
