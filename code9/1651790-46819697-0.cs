    private const string IsLoginKey = "login_key";
    private static readonly bool IsLoginDefault = false;
    //Then adding this property
    public static bool IsLogin
    {
        get
        {
            return AppSettings.GetValueOrDefault(IsLoginKey, IsLoginDefault);
        }
        set
        {
            AppSettings.AddOrUpdateValue(IsLoginKey, value);
        }
    }
