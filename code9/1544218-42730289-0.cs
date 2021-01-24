    public class Singleton {
      private static readonly AsyncLazy<Singleton> instance =
          new AsyncLazy<Singleton>( CreateAndDoSomething );
      private Singleton() {
      }
      // This method could also be an async lambda passed to the AsyncLazy constructor.
      private static async Task<Singleton> CreateAndDoSomething() {
         var ret = new Singleton();
         await ret.InitAsync();
         return ret;
      }
      private async Task InitAsync() {
         await Stuff();
      }
      public static AsyncLazy<Singleton> Instance
      {
         get { return instance; }
      }
    }
