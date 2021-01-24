    public class C1 {
      public virtual void MyMethod() {
      }
    }
    public class C2 : C1 {
      public sealed override void MyMethod() {
         base.MyMethod();
      }
    }
