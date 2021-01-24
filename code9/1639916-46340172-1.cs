    private static YourForm _instance;
    /// <summary>
    /// static Instance of YourForm 
    /// </summary>
    public static YourForm Instance
    {
      get
      {
        if (_instance == null)
          _instance = new YourForm();
        return _instance;
      }
    }
