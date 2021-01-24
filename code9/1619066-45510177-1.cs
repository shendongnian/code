    [assembly: Dependency(typeof(AppVersionProvider))]
    namespace MyApp.iOS
    {
        public class AppVersionProvider : IAppVersionProvider
        {
            public string AppVersion => NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
        }
    }
