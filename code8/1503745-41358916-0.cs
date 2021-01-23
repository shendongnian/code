    public class Base
    {
       public final void Method() // Don't allow this to be overridden
       {
          // Do some preparatory stuff here
          // Then call a method that might be overridden
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
