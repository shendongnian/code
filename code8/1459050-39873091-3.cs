    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IDependency, Dependency1>();
            unityContainer.RegisterType<IPropertyDependency, PropertyDependency1>();
            WindsorContainer castleContainer = new WindsorContainer();
            castleContainer.Kernel.Resolver.AddSubResolver(new UnityResolver(unityContainer));
            castleContainer.Register(
               Component.For<SomeType>());
            var result = castleContainer.Resolve<SomeType>();
        }
    }
    public interface IDependency { void Foo(); }
    public class Dependency1 : IDependency { public void Foo() { } }
    public interface IPropertyDependency { }
    public class PropertyDependency1 : IPropertyDependency { }
    public class SomeType
    {
        public SomeType(IDependency dependency) { ConstructorDependency = dependency; }
        public IDependency ConstructorDependency { get; private set; }
        public IPropertyDependency PropertyDependency { get; set; }
    }
    public class UnityResolver : ISubDependencyResolver
    {
        public UnityResolver(UnityContainer container)
        {
            Container = container;
        }
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            return Container.Registrations.Any(z => z.RegisteredType.Equals(dependency.TargetType));
        }
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            return Container.Resolve(dependency.TargetType);
        }
        public UnityContainer Container { get; set; }
    }
