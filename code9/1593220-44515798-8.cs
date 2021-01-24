    public partial class HostOwin : ServiceBase
    {
        private IDisposable owin;
        public HostOwin()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            owin = WebApp.Start<Startup>(url: baseAddress);
    
        }
    
        protected override void OnStop()
        {
            owin.Dispose();
        }
    }
