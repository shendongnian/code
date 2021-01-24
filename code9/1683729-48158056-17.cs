    public class Derived : Base
    {
      public new void Foo(int x)
      { 
        Console.WriteLine("Derived.Foo(int)");
      }
      public void Foo(object o)
      {
        Console.WriteLine("Derived.Foo(object)");
      }
    }
