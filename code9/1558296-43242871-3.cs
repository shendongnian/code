    // should only be visible in test project
    internal class StubAssemlbyProvider : IAssemblyProvider
    {
          public Assembly GetEntryAssembly()
          {
               return typeof(MyClassInEntryAssembly).Assembly;
          }
    }
