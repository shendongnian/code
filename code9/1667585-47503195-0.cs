        private CallstackCollapserDataItem()
        {
            string registryRoot = DkmGlobalSettings.RegistryRoot;
            string propertyPath = "vsix\\CallstackCollapserOptionPageGrid";
            string fullKey = "HKEY_CURRENT_USER\\" + registryRoot + "\\ApplicationPrivateSettings\\" + propertyPath;
            string savedStringSetting = (string)Registry.GetValue(fullKey, "SearchStrings", "");
            string semicolonSeparatedStrings = "";
            // The setting resembles "1*System String*Foo;Bar"
            if (savedStringSetting != null && savedStringSetting.Length > 0 && savedStringSetting.Split('*').Length == 3)
            {
                semicolonSeparatedStrings = savedStringSetting.Split('*')[2];
            }
        }
