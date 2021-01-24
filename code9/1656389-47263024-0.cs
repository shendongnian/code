    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurationsFromCurrentAssembly(this ModelBuilder modelBuilder, string configNamespace= "")
        {
            var applyGenericMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);
            var applicableTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters);
            
            if(!string.IsNullOrEmpty( configNamespace))
            {
                applicableTypes = applicableTypes.Where(c => c.Namespace == configNamespace);
            }
            foreach (var type in applicableTypes)
            {
                foreach (var iface in type.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        // make concrete ApplyConfiguration<SomeEntity> method
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        // and invoke that with fresh instance of your configuration type
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        break;
                    }
                }
            }
        }
    }
