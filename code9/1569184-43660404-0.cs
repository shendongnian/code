    public static class DependencyResolver
    {
        public static CompositionHost Container { get; set; }
        public static void SatisfyImports(object arg)
        {
            Container.SatisfyImports(arg);
            var props = arg.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var prop in props)
            {
                if (prop.GetCustomAttributes().Contains(new ImportAttribute()))
                {
                    object value = prop.GetValue(arg);
                    SatisfyImports(value);
                }
            }
        }
    }
