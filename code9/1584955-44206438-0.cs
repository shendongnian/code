    using System.Web.Http.Dependencies;
    using global::Ninject.Syntax;
    public class DependencyResolverWebApiNinject : DependencyScopeWebApiNinject, IDependencyResolver
    {
        public DependencyResolverWebApiNinject(IResolutionRoot resolutionRoot)
            : base(resolutionRoot)
        {
        }
        public virtual IDependencyScope BeginScope()
        {
            return this;
        }
    }
