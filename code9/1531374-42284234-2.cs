    public class B : A {
       public override string SomeProperty
       {
          get
          {
             return "whatever";
          }
    
          set
          {
             return; // keep interface happy
          }
       }
    
       public override void DoWork() {
          // I am not doing nothing but compiler is happy
       }
    }
