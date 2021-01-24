    public static async Task ToggleServiceStatus(this EdiServiceInfo serviceInfo)
            {
                await Task.Factory.StartNew(() =>
                {
                    using (
                        Impersonation.LogonUser(serviceInfo.Domain, serviceInfo.User, serviceInfo.Pswd,
                            Environment.MachineName.Equals(serviceInfo.ComputerName,
                                StringComparison.InvariantCultureIgnoreCase)
                                ? LogonType.Network
                                : LogonType.Interactive))
                    {
                        var service = new ServiceController(serviceInfo.ServiceName, serviceInfo.ComputerName);
                        if (service.Status == ServiceControllerStatus.Stopped)
                        {
                            service.Start();
                            service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(60));
                        }
                        else
                        {
                            service.Stop();
                            service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(60));
                        }
                    }
                });
            }
