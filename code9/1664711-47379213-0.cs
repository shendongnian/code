    public class Singleton
    {      
      protected Singleton() { }
      private sealed class SingletonCreator
      {
        private static readonly Singleton instance = new Singleton();
        public static Singleton Instance { get { return instance; } }
      }
      public static Singleton Instance
      {
        get { return SingletonCreator.Instance; }
      }
    }
