    public class Base
    {
         public void Method()
         {
            // Do some preparatory stuff here, then call a method that might be overridden
            MethodImpl()
         }
         protected virtual void MethodImpl() // Not accessible apart from child classes
         {      
         }
    }
    
    public class Parent : Base
    {
        protected override void MethodImpl()
        {
           // ToDo - implement to taste
        } 
    }
