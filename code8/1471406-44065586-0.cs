    public static void setDNS(string NIC, string DNS)
    {
        ConnectionOptions options = PrepareOptions();
        ManagementScope scope = PrepareScope(Environment.MachineName, options, @"\root\CIMV2");
        ManagementPath managementPath = new ManagementPath("Win32_NetworkAdapterConfiguration");
        ObjectGetOptions objectGetOptions = new ObjectGetOptions();
        ManagementClass mc = new ManagementClass(scope, managementPath, objectGetOptions);
        ManagementObjectCollection moc = mc.GetInstances();
        foreach (ManagementObject mo in moc)
        {
            if ((bool)mo["IPEnabled"])
            {
                if (mo["Caption"].ToString().Contains(NIC))
                {
                    try
                    {
                        ManagementBaseObject newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");
                        newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                        ManagementBaseObject setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        Console.ReadKey();
                        throw;
                    }
                }
            }
        }
    }
