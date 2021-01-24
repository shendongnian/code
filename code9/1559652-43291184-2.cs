    public sealed class MyClass : IDisposable
    {
         private File txtFile = new File.Create(...)
         
         public void Dispose()
         {
              txtFile.Dispose();
              GC.SuppressFinalize(this);
         }
         ~MyClass() => Dispose();
    }
