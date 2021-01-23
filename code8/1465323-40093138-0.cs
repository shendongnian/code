    public static class Themes {
        private static IThemeSettings themes;
        public static void Configure(Func<IThemeSettings> factory) {
            if (factory == null) throw new InvalidOperationException("Must provide a valid factory method");
            themes = factory();
        }
        public static string GetDefaultName(bool isResponsive) {
            if (themes == null) throw new InvalidOperationException("Themes has not been configured.");
            string result = string.Empty;
            if (!isResponsive) {
                if (themes.Contains("defaultTheme")) {
                    result = themes["defaultTheme"];
                } else
                    result = "default";
            } else {
                // ...
            }
            return result;
        }
        //...
    }
