        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Apple Inc.\Apple Application Support"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("Installdir");
                    if (o != null)
                    {
                      // do something
                    }
                }
            }
