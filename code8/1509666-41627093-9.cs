    public static class Auth {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }
    }
    
    public partial class Startup {
        public void ConfigureAuth(IAppBuilder app) {
            Auth.DataProtectionProvider = app.GetDataProtectionProvider();
            //...other code removed for brevity
        }
    }
