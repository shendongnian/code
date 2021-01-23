     public interface IPluginObject
     {
          void Foo();
          IBlah Bar();
          ...
     }
 
     public Wrapper<T>: IPluginObject where T: IPluginObject
     {
          private readonly T inner;
          public Wrapper(IPlugin obj) { inner = obj; }
          public void Foo()
          {
               try { inner.Foo() }
               catch ....
               finally ...
          }
          public IBlah Bar()
          {
               try { return inner.Bar(); }
               catch ...
               finally ...
          }
     }
