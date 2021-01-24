    public partial class Startup
        {
          public static IDataProtectionProvider DataProtectionProvider { get; set; }
          
            public void ConfigureAuth(IAppBuilder app)
            {
               DataProtectionProvider = app.GetDataProtectionProvider();
            }
    }
