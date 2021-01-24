    public interface IA
    {
         bool PropertyDummy { get; set; }
    }
    public class A : IA
    {
       public bool ProprertyDummy
       {
          get;
          set;
       }
    }
    public class B {
       private IA _ia;
       public B(IA ia) { _ia = ia; }
    }
