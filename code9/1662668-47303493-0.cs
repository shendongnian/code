    public interface IDependencyFactory
    {
        IDependency Create(Controller controller);
    }
    public class MyController : Controller
    {
        private IDependency dependency;
        public MyController(IDependencyFactory dependencyFactory)
        {
            this.dependency = dependencyFactory.Create(this);
        }
    }
    var kernel = new StandardKernel();
    kernel.Bind<Controller>().To<MyController>();
    kernel.Bind<IDependency>().To<DependencyImplementation>();
    kernel.Bind<IDependencyFactory>().ToFactory();
    var controller = kernel.Get<Controller>();
