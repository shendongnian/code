    public static class Settings
    {
         public static string Scheme => ConfigurationManager.AppSettings["Scheme"];
         public static string Host => ConfigurationManager.AppSettings["Host"];
         public static string Path => ConfigurationManager.AppSettings["Path"];
         public static Uri BaseUri => new Uri(String.Concat(Scheme, Host));
         public static Uri SomeUri => new Uri(BaseUri, Path);
    }
