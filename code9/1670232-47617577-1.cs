public class ModuleOneDependenciesManager : IAspNetCoreDependenciesManager
{
    public virtual void ConfigureDependencies(IServiceProvider serviceProvider, IServiceCollection services, IDependencyManager dependencyManager)
    {
        dependencyManager.Register<Module1Contract, Module1Implementation>();
    }
}
