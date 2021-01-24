    public class ClassName
    {
        public delegate ClassName Factory(Type1 obj1, string obj2);
        public ClassName(Type1 obj1, string obj2)
        {
            this.type1 = obj1;
            this.type2= obj2;
        }
    }
    
    // Registration 
    container.RegisterType<ClassName>().AsSelf().InstancePerDependency();
    
    // In some method to create an instance of ClassName
    var factory = container.Resolve<ClassName.Factory>();
    var instance = factory.Invoke(obj1Instance, "text");
