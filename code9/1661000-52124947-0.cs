    public static string GetWindowsProductKey ()
            {
            RegistryKey environmentKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,"SOMANATHAN",RegistryView.Default ).OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            
                var isWin8OrUp =
                    (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 2)
                    ||
                    (Environment.OSVersion.Version.Major > 6);
                var productKey = isWin8OrUp ? DecodeProductKeyWin8AndUp(digitalProductId) : DecodeProductKey(digitalProductId);
                environmentKey.Close();
                return productKey;
            }
