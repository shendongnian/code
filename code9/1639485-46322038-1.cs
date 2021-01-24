    using System;
    namespace A {
      namespace B { 
        using C;
        class D 
        {
          public static void E() {}
        }
        class F : D {
          public static void G() {}
          public void H()
          {
            Action i = ()=>{};
            
