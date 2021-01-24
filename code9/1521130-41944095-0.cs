    ManagementScope oMs = new ManagementScope();  
    ObjectQuery oQuery =  
        new ObjectQuery("Select * From Win32_NetworkAdapter");  
    ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);  
    ManagementObjectCollection oReturnCollection = oSearcher.Get();  
    foreach (ManagementObject oReturn in oReturnCollection) 
    {
        if (oReturn.Properties["NetConnectionID"].Value != null)  
            {
                Console.WriteLine("Name : " + oReturn.Properties["NetConnectionID"].Value);
            }
    } 
