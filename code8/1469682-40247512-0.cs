        using System.Net;
        using System.Security.Cryptography;
        using System.Security.Cryptography.X509Certificates;
    
        public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            var certs = store.Certificates.Find(X509FindType.FindByThumbprint, "Your thumb", false);
