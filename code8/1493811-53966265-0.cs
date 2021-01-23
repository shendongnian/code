    public static class SettingsHelper
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        #region Setting Constants
        private const string LoginKey = "login_key";
        private static readonly string SettingsDefault = string.Empty;
        #endregion
        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(LoginKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LoginKey, value);
            }
        }
    }
