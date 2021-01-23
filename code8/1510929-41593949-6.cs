    public interface IMyClass
    {
        void Run();
    }
    public interface IDependency1
    {
        void DoSomething();
    }
    public interface IDependency2
    {
        void DoSomethingElse();
    }
    public class MyClass : IMyClass
    {
        public readonly IDependency1 dep;
        public MyClass(IDependency1 dep)
        {
            this.dep = dep;
        }
        public void Run()
        {
            this.dep.DoSomething();
        }
    }
    public class Dependency1 : IDependency1
    {
        public readonly IDependency2 dep;
        public MyClass(IDependency2 dep)
        {
            this.dep = dep;
        }
        public void DoSomething()
        {
            this.dep.DoSomethingElse();
        }
    }
    public class Dependency2 : IDependency2
    {
        public void DoSomethingElse()
        {
        }
    }
