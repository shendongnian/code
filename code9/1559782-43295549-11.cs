    using (ServiceHost host = new ServiceHost(typeof(ExcelDataService)))
    {
         PrintEndpoints(host.Description);
         host.Open();
         Console.WriteLine("Service(s) are up and running... Press Enter key to exit!");
         Console.ReadLine();
    }
