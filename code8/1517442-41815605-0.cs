     ConnectionOptions connection = new ConnectionOptions();
     connection.Impersonation = ImpersonationLevel.Impersonate;
     ManagementScope scope = new ManagementScope("\\root\\CIMV2", connection); 
     scope.Connect(); 
     ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");
     ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
     foreach (ManagementObject queryObj in searcher.Get()) 
     { 
     Console.WriteLine("-----------------------------------");
       foreach (PropertyData data in queryObj.Properties)
        Console.WriteLine(data.Name + "\t" + data.Value); 
     }
