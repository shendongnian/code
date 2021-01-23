    public class Transaction
    {
        private Transaction(){} // private important!
    
        public static Transaction Create(object creator)
        {
            if(creator is IService)
                return new Transaction();
    
            throw new InvalidOperationException();
        }
    }
    
    public class ServiceA : IService
    {
        public void MethodA() 
        {
            var transaction = Transaction.Create(this);  // works
        }
    }
    
    
    public class ServiceB
    {
        public void MethodA() 
        {
            var transaction = Transaction.Create(this);  // fails
        }
    }
