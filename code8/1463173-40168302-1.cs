    // using System.Net.Http;
    // using System.Security.Authentication;
    // using System.Security.Cryptography.X509Certificates;
    var handler = new HttpClientHandler();
    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
    handler.SslProtocols = SslProtocols.Tls12;
    handler.ClientCertificates.Add(new X509Certificate2("cert.crt"));
    var client = new HttpClient(handler);
    var result = client.GetAsync("https://apitest.startssl.com").GetAwaiter().GetResult();
