    public class Controller
    {
        public Controller(IDependencyFactory dependency) { }
    }
    public interface IDependencyFactory
    {
        IDependency CreateDependency();
    }
    public interface IDependency
    {
    }
    public class Dependency : IDependency
    {
        public Dependency() { }
    }
    public class Program
    {
        public static void Main()
        {
            var standardKernel = new StandardKernel();
            standardKernel.Bind<IDependencyFactory>().ToFactory();
            standardKernel.Bind<IDependency>().To<Dependency>();
        }
    }
