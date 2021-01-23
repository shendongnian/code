    using System;
    class MainClass {
      public static void Main (string[] args) {
        Foo foo1 = new Foo();
        foo1.i = 1;
        Console.WriteLine("Main(): foo1.i: {0}", foo1.i);
        
        doStuffToFoo(foo1, 5);
        Console.WriteLine("Main(): foo1.i: {0}", foo1.i);
        
        Console.WriteLine();
        
        Bar bar1;
        bar1.j = 1;
        Console.WriteLine("Main(): bar1.j: {0}", bar1.j);
        
        doStuffToBar(bar1, 5);
        Console.WriteLine("Main(): bar1.j: {0}", bar1.j);
      }
      
      static void doStuffToFoo(Foo aFoo, int aInt) {
        aFoo.i = aInt;
        aFoo = new Foo();
        aFoo.i = 123;
        Console.WriteLine("doStuffToFoo: aFoo.i: {0}", aFoo.i);
      }
      
      static void doStuffToBar(Bar aBar, int aInt) {
        aBar.j = aInt;
        aBar = new Bar();
        aBar.j = 123;
        Console.WriteLine("doStuffToBar: aBar.j: {0}", aBar.j);
      }
    }
    
    class Foo {
      public int i;
    }
    
    struct Bar {
      public int j;
    }
