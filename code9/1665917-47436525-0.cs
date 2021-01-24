    public static class LanguageSetter
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern ushort SetThreadUILanguage(ushort _languageId);
        public static void SetLanguage(string uiLanguage)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(uiLanguage);
            SetThreadUILanguage((ushort) Thread.CurrentThread.CurrentUICulture.LCID);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(uiLanguage);
        }
    }
