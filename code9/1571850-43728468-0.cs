    string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    List<string>displayNames = new List<string>();
    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
    {
        foreach (string subkeyName in key.GetSubKeyNames())
        {
            using (RegistryKey productKey = key.OpenSubKey(subkeyName))
            {
                var displayName = Convert.ToString(productKey.GetValue("DisplayName"));
                if (!string.IsNullOrWhiteSpace(displayName)) displayNames.Add(displayName);
            }
        }
    }
    var fileName = @"c:\temp\DisplayNames.txt";
    File.WriteAllLines(fileName, displayNames);
