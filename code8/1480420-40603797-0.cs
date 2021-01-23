    public partial class Service : ServiceBase
    {
        private ServiceHost _host;
        private KSPDJOBWinWCFService _instance;
        
        protected override void OnStart(string[] args)
        {
            try
            {
                _instance = new KSPDJOBWinWCFService();
                _instance.EventA += HandleEventA;
                _host = new ServiceHost(_instance);
                _host.Open();
            }
            catch (Exception ex)
            {
                // Logging
            }
        }
        public void HandleEventA(object sender, CustomEventArgs e)
        {
            // do whatever you want here
            var localVar = e.Value;
        }
        protected override void OnStop()
        {
            try
            {
                if (_instance != null)
                {
                    _instance.Dispose();
                }
                _host.Close();
            }
            catch (Exception ex)
            {
                // Logging
            }
        }
    }
