    public abstract class Base<T> where T : Base<T>
    {
      protected static Environment Environment { get; private set; }
      public static void Init(Environment newEnvironment)
      {
        Environment = newEnvironment;
      }
    }
