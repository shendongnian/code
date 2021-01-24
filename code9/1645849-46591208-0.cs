           public static Boolean WriteToRegistry(String[] OEMInformations)
        {
            try
            {
                for (int i = 0; i < OEMInformations.Length; i = i +2)
                {
                    RegistryKey mainKey = Registry.LocalMachine;
                    RegistryKey firstKey = mainKey.OpenSubKey("SOFTWARE", true);
                    RegistryKey secondKey = firstKey.OpenSubKey("Microsoft", true);
                    RegistryKey thirdKey = secondKey.OpenSubKey("Windows", true);
                    RegistryKey fourthKey = thirdKey.OpenSubKey("CurrentVersion", true);
                    RegistryKey fifthKey = fourthKey.OpenSubKey("OEMInformation", true);
                    fifthKey.SetValue(OEMInformations[i],OEMInformations[i + 1], RegistryValueKind.String);
                    fifthKey.Close();
                    fourthKey.Close();
                    thirdKey.Close();
                    secondKey.Close();
                    firstKey.Close();
                    mainKey.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
