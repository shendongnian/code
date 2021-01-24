    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Registry.BuildContainer())
            {
                var theInstance = registry.Resolve<IFirstSingleInstance>();
                theInstance.DoThis();
            }
        }
    }
    public static class Registry
    {
        public static UnityContainer BuildContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IFirstSingleInstance, FirstSingleInstance>(Singleton);
            container.RegisterType<ISecondSingleInstance, SecondSingleInstance>(Singleton);
            return container;
        }
        private static ContainerControlledLifetimeManager Singleton => 
            new ContainerControlledLifetimeManager();
    }
    public interface ISecondSingleInstance
    {
        void DoThisToo();
    }
    public interface IFirstSingleInstance
    {
        void DoThis();
    }
    public class FirstSingleInstance : IFirstSingleInstance
    {
        private ISecondSingleInstance _second;
        public FirstSingleInstance(ISecondSingleInstance second)
        {
            _second = second;
        }
        public void DoThis()
        {
            System.Console.WriteLine("This Was Done.");
            _second.DoThisToo();
        }
    }
    public class SecondSingleInstance : ISecondSingleInstance
    {
        public SecondSingleInstance(/* other dependencies here */)
        {
        }
        public void DoThisToo()
        {
            System.Console.WriteLine("This Was Done too.");
        }
    }
