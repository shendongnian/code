    class A
    {
                    
    //Proper Immutable property works only c# 6 
          public B1 B1 { get; }
          public B2 B2 { get; }
          public A(B1 b1 = null, B2 b2 = null)
          {
               B1 = b1??new B1();
               B2 = b2??new B2();
          }
    }
