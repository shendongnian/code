    public static void SetDNS(string DnsString)
    {
    	string[] Dns = { DnsString };
    	var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
    	if (CurrentInterface == null) return;
    
    	ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
    	ManagementObjectCollection objMOC = objMC.GetInstances();
    	foreach (ManagementObject objMO in objMOC)
    	{
    		if ((bool)objMO["IPEnabled"])
    		{
    			if (objMO["Caption"].ToString().Contains(CurrentInterface.Description))
    			{
    				ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
    				if (objdns != null)
    				{
    					objdns["DNSServerSearchOrder"] = Dns;
    					objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
    				}
    			}
    		}
    	}
    }
