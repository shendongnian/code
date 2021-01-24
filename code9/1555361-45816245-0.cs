    public static bool IsEnabled()
        {
            try
            {
                //root\standardcimv2\embedded
                ManagementScope scope = new ManagementScope(@"root\standardcimv2\embedded");
                using (ManagementClass mc = new ManagementClass(scope.Path.Path, "UWF_Filter",
                null))
                {
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        // Please make use of NextEnabled property in case you have enabled the UWF_Filter in the current session. 
                        //The value in CurrentEnabled is populated only when the UWF_Filter was enabled on system boot.
                        return (bool)mo.GetPropertyValue("CurrentEnabled");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return false;
        }
