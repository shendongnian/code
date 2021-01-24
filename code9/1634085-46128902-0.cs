    public class MyClass : ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
    
        public MyClass()
        {
            AbpSession = NullAbpSession.Instance;
        }
    
        public void MyMethod()
        {
            var currentUserId = AbpSession.UserId;
            //...
        }    
    
    }
