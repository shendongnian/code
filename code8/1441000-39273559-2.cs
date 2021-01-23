     public interface IExample<T>
     {
         ...
     }
     public static class Example
     {
         private class Example<T>: IExample<T> { ... }
         public static IExample<T> Create<T>() { ... }
         ....
      }
            
