    public class SubSys1AppModule : IAspNetCoreAppModule // It's possible in owin based apps by implementing IOwinAppModule
    {
        public virtual void ConfigureDependencies(IServiceProvider serviceProvider, IServiceCollection services, IDependencyManager dependencyManager)
        {
            dependencyManager.Register<Module1Contract, Module1Implementation>();
        }
    }
