    public static void createRegistry()
        {
            string filename = Process.GetCurrentProcess().MainModule.FileName;
            filename = filename.Substring(filename.LastIndexOf('\\') + 1, filename.Length - filename.LastIndexOf('\\') - 1);
            if (filename.Contains("vhost"))
                filename = filename.Substring(0, filename.IndexOf('.') + 1) + "exe";
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true).SetValue(filename, 11001, RegistryValueKind.DWord);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BEHAVIORS", true).SetValue(filename, 11001, RegistryValueKind.DWord);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true).SetValue(filename, 11001, RegistryValueKind.DWord);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BEHAVIORS", true).SetValue(filename, 11001, RegistryValueKind.DWord);
        }
        public static void removeRegistry()
        {
            string filename = Process.GetCurrentProcess().MainModule.FileName;
            filename = filename.Substring(filename.LastIndexOf('\\') + 1, filename.Length - filename.LastIndexOf('\\') - 1);
            if (filename.Contains("vhost"))
                filename = filename.Substring(0, filename.IndexOf('.') + 1) + "exe";
            try
            {
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true).DeleteValue(filename);
            }
            catch
            {
            }
            try
            {
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BEHAVIORS", true).DeleteValue(filename);
            }
            catch
            {
            }
            try
            {
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true).DeleteValue(filename);
            }
            catch
            {
            }
            try
            {
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BEHAVIORS", true).DeleteValue(filename);
            }
            catch
            {
            }
        }
