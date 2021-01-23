        bool AppNameInBaloon = false;
        string BuildString = ReadHKLMValue(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild");
        int CurrentBuild;
        bool WasParsed = Int32.TryParse(BuildString, out CurrentBuild);
        if (WasParsed)
        {
            if (CurrentBuild >= 14393)
            {
                AppNameInBaloon = true;
            }
        }
    private static string ReadHKLMValue(string regPath, string value)
        {
            RegistryKey localKey;
            if (Environment.Is64BitOperatingSystem)
            {
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            }
            string keyValue;
            try
            {
                keyValue = localKey.OpenSubKey(regPath).GetValue(value).ToString();
                return keyValue;
            }
            catch
            {
                keyValue = "";
            }
            return keyValue;
        }
