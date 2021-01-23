    /// <summary>
    /// Set's the DNS Server of the local machine
    /// </summary>
    /// <param name="NIC">NIC address</param>
    /// <param name="DNS">DNS server address</param>
    /// <remarks>Requires a reference to the System.Management namespace</remarks>
    public void setDNS(string NIC, string DNS)
    {
        ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection objMOC = objMC.GetInstances();
        foreach (ManagementObject objMO in objMOC)
        {
            if ((bool)objMO["IPEnabled"])
            {
                // if you are using the System.Net.NetworkInformation.NetworkInterface you'll need to change this line to if (objMO["Caption"].ToString().Contains(NIC)) and pass in the Description property instead of the name 
                if (objMO["Caption"].Equals(NIC))
                {
                    try
                    {
                        ManagementBaseObject newDNS =
                            objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                        ManagementBaseObject setDNS =
                            objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
