    public interface IFoo<T> where T : class
    {
      string Process(T value);
    }
    
    public class FooHelper<T> : IFoo<T> where T : class
    {
      public string Process(T value)
      {
        return "DepController";
      }
    }
