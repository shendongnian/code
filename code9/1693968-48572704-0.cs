    namespace AccountCommandService
    {
        internal static class Program
        {
            private static void Main()
            {
                try
                {
                    ServiceRuntime.RegisterServiceAsync("AccountCommandServiceType",
                        context =>
                        {
                            // Create IoC container
                            var kernel = new ServiceKernel(context);
                            
                            // Create Service
                            return new AccountCommandService(context, 
                                kernel.Get<IAccountDataContextFactory>(), // Pull a DBContext factory from the IoC
                                );
                        }).GetAwaiter().GetResult();
 
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (Exception e)
                {
                    ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                    throw;
                }
            }
        }
    }
