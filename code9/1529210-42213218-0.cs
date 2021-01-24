    private void ReadRegistry()
    {
        string[] allSubKeys = Registry.LocalMachine.OpenSubKey(paths.mainKey).GetSubKeyNames();
        if (allSubKeys.Contains("Razer Chroma SDK"))
        {
            var subKey = Registry.LocalMachine.OpenSubKey(paths.subKey);
            string[] allDayPolicies = subKey.GetValueNames();
            foreach (string name in allDayPolicies)
            {
                var value = subKey.GetValue(name);
                // do something with value
            }
        }
    }
