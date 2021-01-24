    public interface IAssemblyProvider
    {
          Assembly GetEntryAssembly();
    }
    public class AssemlbyProvider
    {
          public Assembly GetEntryAssembly()
          {
               return Assembly.GetEntryAssembly();
          }
    }
