    foreach (ServiceController scTemp in scServices)
    {
       if (scTemp.Status == ServiceControllerStatus.Running)
       {
          Console.WriteLine("  Service :        {0}", scTemp.ServiceName);
          Console.WriteLine("    Display name:    {0}", scTemp.DisplayName);
         // if needed: additional information about this service.
         ManagementObject wmiService;
         wmiService = new ManagementObject("Win32_Service.Name='" +
         scTemp.ServiceName + "'");
         wmiService.Get();
         Console.WriteLine("    Start name:      {0}", wmiService["StartName"]);
         Console.WriteLine("    Description:     {0}", wmiService["Description"]);
       }
    }
