    public class RSDatabaseConnectionCreator : LoggerBase
    {
        public virtual object CreateConnection() // by virtual you can override it.
        {
          return new object();
        }
    }
    
    public class AnotherClass : RSDatabaseConnectionCreator {
    
        public AnotherClass() {
            CreateConnection(); // by inheriting RSDatabaseConnectionCreator , you can reach public functions.
        }
    
        public override object CreateConnection() // or you can override it 
        {
            // here might be some user Login check
            return base.CreateConnection(); // then you open connection
        }
    }
