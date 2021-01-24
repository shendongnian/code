    // Foreign.DLL
    namespace F 
    { 
      public class B 
      {
        public void Foo() { }
      }
    }
    // Local.DLL
    interface IFooBar 
    { 
      void Foo();
      void Bar();
    }
    class D : F.B, IFooBar
    {
      public void Bar() { }
    }
