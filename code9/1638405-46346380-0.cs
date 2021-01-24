    public class InitializerModule : IHttpModule
    {
        public void Dispose() { }
        public void Init(HttpApplication context)
        {
            // Sets the TLS version for every request made to an external party
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
