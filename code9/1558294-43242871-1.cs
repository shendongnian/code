    // should only be visible in test project
    internal class StubAssemlbyProvider
    {
          public Assembly GetEntryAssembly()
          {
               return typeof(MyClassInEntryAssembly).Assembly;
          }
    }
