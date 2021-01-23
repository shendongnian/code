    public static class Mother
    {
         private static Child _child = new Child();
    
         public static IChild Child
         {
              get { return _child; }
         }
    }
    
    public interface IChild
    {
        // public stuff here
        bool SomeMethod();
    }
    
    
    internal class Child : IChild
    {
        public bool SomeMethod() { ... }
        // additional internal members here
    }
