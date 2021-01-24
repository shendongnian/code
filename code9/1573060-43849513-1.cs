    private static TDependencyType ResolveRootDependency<TDependencyType>(IKernel kernel, CreationContext context)
    {
        foreach (var dependency in context.Handler.ComponentModel.Dependencies)
        {
            if (dependency.DependencyKey == typeof(TDependencyType).AssemblyQualifiedName)
            {
                return kernel.Resolve<TDependencyType>(dependency.ReferencedComponentName);
            }
        }
        return kernel.Resolve<TDependencyType>();
    }
