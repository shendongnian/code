    public interface IStorage
    {
      T GetSession<T>(string key);
      void SetSession<T>(string key, T value);
      T GetGlobal<T>(string key);
      void SetGlobal<T>(string key, T value);
    }
    public void InitVars(IStorage storage)
    {
      storage.SetSession("var1", "someval1");
      storage.SetGlobal("var2", "somval2");
    }
