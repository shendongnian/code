    abstract class Account
    {
       public virtual void Pay()
       {
           // code which may or may not be overridden by the inheritor 
       }
    }
    
    // this class just implements the default pay behaviour
    public class Child1 : Account
    {
    }
    // this class overrides the default pay behaviour
    public class Child2 : Account
    {
       public virtual void Pay()
       {
           // Add your own custom pay functionality 
       }
    }
    // this class calls the default pay behaviour and does other things
    public class Child3 : Account
    {
       //other stuff
       public virtual void Pay()
       {
           // calls the default pay implementation in base class 
           base.Pay();
           // Add your additional pay functionality 
       }
    }
