        public string ReadFromRegistry(string keyName, string defaultValue)
        {
            RegistryKey rootKey = Registry.CurrentUser;
            string registryPath = @"Software\YourCompanyName\YourAddInName";
            using (RegistryKey rk = rootKey.OpenSubKey(registryPath, false))
            {
                if (rk == null)
                {
                    return defaultValue;
                }
                var res = rk.GetValue(keyName, defaultValue);
                if (res == null)
                {
                    return defaultValue;
                }
                return res.ToString();
            }
        }
