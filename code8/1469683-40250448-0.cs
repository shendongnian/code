    using System.Net;
    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        string certfile = System.IO.Path.Combine(Environment.ExpandEnvironmentVariable‌​s("%HOME%"), @"site\wwwroot\HttpTriggerCSharp4\myCertFile.pfx");        
        log.Info(certfile); 
        log.Info(System.IO.File.Exists(certfile).ToString());
        X509Certificate2 cert = new X509Certificate2(certfile, "password", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);     
        log.Info(cert.Thumbprint);
