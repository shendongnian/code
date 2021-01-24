    public class B
    {
         public static explicit operator A(B b)
         {
              return new A() {
                               p1 = b_obj.p1,
                               p3 = b_obj.p3,
                             }
         }
         //...
     }
