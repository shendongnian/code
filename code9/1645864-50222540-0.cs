    public static string CheckService(string ServiceName)
            {
                //check service
                var services = ServiceController.GetServices();
                string serviceStatu = string.Empty;
                bool isServiceExist = false;
                foreach (var s in services)
                {
                    if (s.ServiceName == ServiceName)
                    {
                        serviceStatu = "Service installed , current status: " + s.Status;
                        isServiceExist = true;
                    }
    
    
                }
    
                if (!isServiceExist)
                {
                    serviceStatu= "Service is not installed";
                }
    
                return serviceStatu;
            }
Console.WriteLine(CheckService("Service name"));
