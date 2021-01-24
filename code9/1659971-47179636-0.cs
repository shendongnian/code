    [Serializable]
    public class AppSettings
    {
      public string FileDir { get; set; }
      public AppSettings()
      {
        FileDir = string.Empty;
      }
    
      public AppSettings(string fDir)
      {
        FileDir = fDir;
      }
    
      public void SetDefault()
      {
        FileDir = "SomeDefault";
      }
    }
