    public class Test
    {
       public void Test()
       {
          int[] val = new int[] { 1, 2, 3 };
    
          var C = new C();
          var D = new C.D();
          C.Foo(D, val); // should print 1 2 3
    
          var E = new E();
          C.Foo(E, val); // should print 3 2 1
       }
    }
