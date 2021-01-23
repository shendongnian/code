    public class AppPreferences
    {
        static ISettings AppSettings => CrossSettings.Current;
        public static string UserName
        {
          get { return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault); }
          set { AppSettings.AddOrUpdateValue<string>(UserNameKey, value); }
        }
    }
