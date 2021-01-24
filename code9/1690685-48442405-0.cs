    using Xamarin.Forms;
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    
    namespace MyNamespace
    {
        public static class PropertyStorage
        {
            private const string KeyMyPropertyX = "myPropertyX";
    
            public static string MyPropertyX
            {
                get { return AppSettings.GetValueOrDefault(nameof(TagName), string.Empty, KeyMyPropertyX); }
                set { AppSettings.AddOrUpdateValue(nameof(TagName), value, KeyMyPropertyX); }
            }
    
            private static ISettings AppSettings
            {
                get { return CrossSettings.Current; }
            }
        }
    }
