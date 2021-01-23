    public class Parent : ISomeService
    {
        private IChild m_child;
    
        public Parent(Func<ISomeService, IChild> childFactory)
        {
            m_child = childFactory(this);
        }
    }
    
    public class Child : IChild
    {
        public Child(ISomeService someService)
        {
            // ...store and/or use the service...
        }
    }
    
    // Registration looks like this:
    builder.RegisterType<Parent>(); // registered as self, NOT as ISomeService
    builder.RegisterType<Child>().AsImplementedInterfaces();
