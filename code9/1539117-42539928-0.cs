     [ServiceContract(...)]
     public interface IFoo
     {
          [OperationContract(...)]
          void Bar();
     }
     public class Foo : IFoo 
     {
          public void Bar()
          {
               ...
          }
     }
