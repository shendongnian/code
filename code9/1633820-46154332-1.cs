    using System.Net;
    
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            // rest of Startup.Auth.cs code
        }
    }
