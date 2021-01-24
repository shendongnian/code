    class SomethingDisposable : IDisposable {
       ...       
       public static T Use<T>(Func<SomethingDisposable, T> pFunc) {
          using (var somethingDisposable = new SomethingDisposable())
             return pFunc(somethingDisposable);
       }
       // also a version that takes an Action and returns nothing
       ...
    }
