    public class MyClass
    {
        public void DoSomething()
        {
            var blah = ServiceLocator.Container.Resolve<IBlah>();
        }
    }
