    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                AsyncContext.Run(() => MainAsync());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
        static async Task MainAsync()
        {
    #if (!DEBUG)
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new UnityService()
            };
            ServiceBase.Run(ServicesToRun);
     #else
            UnityService myServ = new UnityService();
            //myServ.SetupService().ConfigureAwait(true);
            await myServ.BeginService();
    #endif
        }
