    public partial class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }
    
        public void ConfigureAuth(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();
            // other stuff.
        }
    }
