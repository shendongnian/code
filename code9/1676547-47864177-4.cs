    public static class OptionsHelper
    {
        public static IEnumerable<object> CreateOptions(IConfiguration configuration)
        {
            // Get all sections that are objects:
            var sections = configuration.GetChildren()
                .Where(section => section.GetChildren().Any());
           foreach (var section in sections)
           {
               // Add "Options" suffix if not done.
               var name = section.Key.EndsWith("Options")
                   ? section.Key 
                   : section.Key + "Options";
               // Scan AppDomain for a matching type.
               var type = FirstOrDefaultMatchingType(name);
               if (type != null)
               {
                   // Use ConfigurationBinder to create an instance with the given data.
                   var settings = section.Get(type);
                   // Encapsulate instance in "Options<T>"
                   var options = CreateOptionsFor(settings);
               }
           }
        }
        private static Type FirstOrDefaultMatchingType(string typeName)
        {
            // Find matching type that has a default constructor
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => !assembly.IsDynamic)
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.Name == typeName)
                .Where(type => !type.IsAbstract)
                .Where(type => type.GetMatchingConstructor(Type.EmptyTypes) != null)
                .FirstOrDefault();
        }
        private static object CreateOptionsFor(object settings)
        {
            // Call generic method Options.Create<TOptions>(TOptions options)
            var openGeneric = typeof(Options).GetMethod(nameof(Options.Create));
            var method = openGeneric.MakeGenericMethod(settings.GetType());
            return method.Invoke(null, new[] { settings });
        }
    }
