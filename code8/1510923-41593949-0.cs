        var container = new Container();    
        container.Register<IInterface>.For<Class>();
    container.Register<IDependency>.For <Dependency>();
    var myclass = container.Resolve<IInterface>();
    myclass.Run();
    }
    public interface IInterface
    {
        void Run();
    }
    public class Class : IInterface
    {
        private readonly IDependency dep;
        public Class(IDependency dep)
        {
            this.dep = dep;
        }
        public void Run()
        {
        }
    }
    public interface IDependency {}
    public class Dependency : IDependency {}
