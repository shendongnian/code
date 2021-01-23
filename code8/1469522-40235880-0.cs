    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            
            container.RegisterType<IClassC, ClassC>();
            container.RegisterType<IClassD, ClassD1>(nameof(ClassD1), new HierarchicalLifetimeManager());
            container.RegisterType<IClassD, ClassD2>(nameof(ClassD2), new HierarchicalLifetimeManager());
            container.RegisterType<IClassA, ClassA>(new InjectionConstructor(Factory.GetClassC<ClassD1>(container)));
            container.RegisterType<IClassB, ClassB>(new InjectionConstructor(Factory.GetClassC<ClassD2>(container)));
            var classA = container.Resolve<IClassA>();
            var classB = container.Resolve<IClassB>();
            classA.HelloFromA();
            classB.HelloFromB();
        }
    }
    public class Factory
    {
        public static IClassC GetClassC<TClassD>(IUnityContainer container)
            where TClassD : IClassD
        {
            return container.Resolve<IClassC>(new DependencyOverride<IClassD>(
                container.Resolve<IClassD>(typeof(TClassD).Name)));
        }
    }
    public interface IClassA
    {
        void HelloFromA();
    }
    public interface IClassB
    {
        void HelloFromB();
    }
    public interface IClassC
    {
        void HelloFromC();
    }
    public interface IClassD { }
    public class ClassA : IClassA
    {
        private readonly IClassC _classC;
        public ClassA(IClassC classC)
        {
            _classC = classC;
        }
        public void HelloFromA()
        {
            _classC.HelloFromC();
        }
    }
    public class ClassB : IClassB
    {
        private readonly IClassC _classC;
        public ClassB(IClassC classC)
        {
            _classC = classC;
        }
        public void HelloFromB()
        {
            _classC.HelloFromC();
        }
    }
    public class ClassC : IClassC
    {
        private readonly IClassD _classD;
        public ClassC(IClassD classD)
        {
            _classD = classD;
        }
        public void HelloFromC()
        {
            Console.WriteLine(string.Format("Hello with {0}", _classD.GetType().Name));
        }
    }
    public class ClassD1 : IClassD
    {
    }
    public class ClassD2 : IClassD
    {
    }
