     var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
            var key = localMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            var subKey = key.OpenSubKey("MyApp.exe", true);
            if (subKey == null)
            {
                subKey = key.CreateSubKey("MyApp.exe");                 
            }
            subKey.SetValue("MyApp.exe", 10001);
