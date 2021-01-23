    public class MyClass
    {
        public Run()
        {
            var dependency = new Dependency1();
            dependency.DoSomething();
        }
    }
    public class Dependency1
    {
        public void DoSomething()
        {
            var dependency = new Dependency2();
            dependeny.DoSomethingElse();
        }
    }
    public class Dependency2
    {
        public void DoSomethingElse()
        {
        }
    }
