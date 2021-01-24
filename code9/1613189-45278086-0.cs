    private static ISettings AppSettings =>
        CrossSettings.Current;
    
    public static string AccessToken
    {
      get => AppSettings.GetValueOrDefault(nameof(AccessToken), string.Empty); 
      set => AppSettings.AddOrUpdateValue(nameof(AccessToken), value); 
    }
