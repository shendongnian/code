    string GetUserEmailFromOffice365()
    {
        string Version = "16.0"; //TODO get from AddIn
        string identitySubKey = $@"Software\Microsoft\Office\{Version}\Common\Identity\Identities";
        using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(identitySubKey))
        {
            if (key.SubKeyCount > 0)
            {
                foreach (var subkeyName in key.GetSubKeyNames())
                {
                    using (var subkey = 
                    {
                        object value = subkey.GetValue("EmailAddress");
                        if (value != null && value is string)
                        {
                            return value as string;
                        }
                    }
                }
            }
        }
        return null;
    }
