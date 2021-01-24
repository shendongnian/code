    public struct Foo
    {
       public int bar;
       public int Baz {
         get { return 0; }
         set { Console.WriteLine(bar); }
       }
       public Foo(int value)
       {
          Baz = 0;
       }
    }
