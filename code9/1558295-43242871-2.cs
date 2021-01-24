    public interface IAssemblyProvider
    {
          Assembly GetEntryAssembly();
    }
    public class AssemlbyProvider : IAssemblyProvider
    {
          public Assembly GetEntryAssembly()
          {
               return Assembly.GetEntryAssembly();
          }
    }
