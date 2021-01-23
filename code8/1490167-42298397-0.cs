    [assembly: OwinStartup(typeof(JOIN8POSShopService.Startup))]
    namespace JOIN8POSShopService
    {
      public partial class Service1 : ServiceBase
        {
            IDisposable SignalR;
            public Service1()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                try
                {
                    ShopAPIAccess.WriteToFile("Join8 POS Service started.");
                    try
                    {
                        SignalR = WebApp.Start(ConfigurationManager.AppSettings["ShopHubURL"].ToString());
                        ShopAPIAccess.WriteToFile("Hub Server Stated");
                    }
                    catch (Exception ex)
                    {
                        ShopAPIAccess.WriteToFile("Error OnStart Shop Signalr Hub " + ex.Message + " ST=" + ex.StackTrace);
                    }
    
                    //string reportTime = await DayEndAutomation();
                    ScheduleService("23:00");
                }
                catch (Exception ex)
                {
                    ShopAPIAccess.WriteToFile("Error OnStart " + ex.StackTrace);
                }
