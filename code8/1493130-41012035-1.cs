    public class A
    {
       public static A LastInstance { get; private set; }
       public A()
       {
          if (this.GetType() == typeof(A))
          {
             LastInstance = this;
          }
       }
    }
    public class B : A
    {
       public static new B LastInstance { get; private set; }
       public B()
       {
          if (this.GetType() == typeof(B))
          {
             LastInstance = this;
          }
       }
    }
