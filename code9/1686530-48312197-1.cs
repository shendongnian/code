    namespace MyAppDomainMgr 
    {
        [ComVisible(true)]
        public class MyCustomAppDomainMgr : AppDomainManager
        {
            public MyCustomAppDomainMgr()
            {
            }
            public override void InitializeNewDomain(AppDomainSetup appDomainInfo)
            {
                Console.Write("Initialize new domain called:  ");
                Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
                InitializationFlags = 
                    AppDomainManagerInitializationOptions.RegisterWithHost;
                // Several ways to control settings of the AppDomainSetup class,
                // or add a delegate for the AppDomain.CurrentDomain.AssemblyResolve 
                // event.
             }
         }
     }
