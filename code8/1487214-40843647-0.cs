        public void StoreInRegistry(string keyName, string value)
        {
            RegistryKey rootKey = Registry.CurrentUser;
            string registryPath = @"Software\YourCompanyName\YourAddInName";
            using (RegistryKey rk = rootKey.CreateSubKey(registryPath))
            {
                rk.SetValue(keyName, value, RegistryValueKind.String);
            }
        }
