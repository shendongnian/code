    public void PoolAction(String servername, String AppPoolName, String action)
        {
            StringBuilder sb = new StringBuilder();
            ConnectionOptions options = new ConnectionOptions();
            options.Authentication = AuthenticationLevel.PacketPrivacy;
            options.EnablePrivileges = true;
            ManagementScope scope = new ManagementScope(@"\\" +
                servername + "\\root\\MicrosoftIISv2", options);
            // IIS WMI object IISApplicationPool to perform actions on IIS Application Pool
            ObjectQuery oQueryIISApplicationPool =
                new ObjectQuery("SELECT * FROM IISApplicationPool");
            ManagementObjectSearcher moSearcherIISApplicationPool =
                new ManagementObjectSearcher(scope, oQueryIISApplicationPool);
            ManagementObjectCollection collectionIISApplicationPool =
                moSearcherIISApplicationPool.Get();
            foreach (ManagementObject resIISApplicationPool in collectionIISApplicationPool)
            {
                if (resIISApplicationPool["Name"].ToString().Split('/')[2] == AppPoolName)
                {
                    // InvokeMethod - start, stop, recycle can be passed as parameters as needed.
                    resIISApplicationPool.InvokeMethod(action, null);
                }
            }
