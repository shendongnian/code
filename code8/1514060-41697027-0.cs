    public class Example
    {
      private Func<string, IMyObject> _workers;
      public Example(Func<string, IMyObject> workers)
      {
        _workers = workers;
      }
      public void DoSomeStuff(string mode) => _workers(mode).DoStuff();
    }
