    public class WebStorage : IStorage
    {
      public T GetSession<T>(string key)
      {
        var result = Session[key] as T;
        return result;
      }
      public void SetSession<T>(string key, T value)
      {
        Session[key] = value;
      }
      // etc with Global
    }
    InitVars(new WebStorage);
