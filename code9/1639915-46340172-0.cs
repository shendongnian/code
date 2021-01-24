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
    }```
YourForm is the form that contain your grid and then you can access to your Grid like this 
