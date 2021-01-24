    public static class DependencyResolver
    {
        public static CompositionHost Container { get; set; }
        public static void SatisfyImports(object arg)
        {
            Container.SatisfyImports(arg);
            var props = arg.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttributes().Contains(new ImportAttribute()));
            foreach (var prop in props)
            {
                object value = prop.GetValue(arg);
                SatisfyImports(value);
            }
        }
    }
