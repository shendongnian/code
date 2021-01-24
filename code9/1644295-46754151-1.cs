    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Titanium.Web.Proxy;
    using Titanium.Web.Proxy.EventArguments;
    using Titanium.Web.Proxy.Models;
    
    namespace ClassLibrary6
    {
        public class ProxySetup
        {
            public ProxySetup()
            {
                var proxyServer = new ProxyServer();
    
                //locally trust root certificate used by this proxy 
                proxyServer.TrustRootCertificate = true;
    
                //optionally set the Certificate Engine
                //Under Mono only BouncyCastle will be supported
                //proxyServer.CertificateEngine = Network.CertificateEngine.BouncyCastle;
    
                proxyServer.BeforeRequest += OnRequest;
                proxyServer.BeforeResponse += OnResponse;
                proxyServer.ServerCertificateValidationCallback += OnCertificateValidation;
                proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;
    
    
                var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true)
                {
                    //Exclude HTTPS addresses you don't want to proxy
                    //Useful for clients that use certificate pinning
                    //for example dropbox.com
                    // ExcludedHttpsHostNameRegex = new List<string>() { "google.com", "dropbox.com" }
    
                    //Use self-issued generic certificate on all HTTPS requests
                    //Optimizes performance by not creating a certificate for each HTTPS-enabled domain
                    //Useful when certificate trust is not required by proxy clients
                    // GenericCertificate = new X509Certificate2(Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "genericcert.pfx"), "password")
                };
    
                //An explicit endpoint is where the client knows about the existence of a proxy
                //So client sends request in a proxy friendly manner
                proxyServer.AddEndPoint(explicitEndPoint);
                proxyServer.Start();
    
                //Transparent endpoint is useful for reverse proxy (client is not aware of the existence of proxy)
                //A transparent endpoint usually requires a network router port forwarding HTTP(S) packets or DNS
                //to send data to this endPoint
                var transparentEndPoint = new TransparentProxyEndPoint(IPAddress.Any, 8001, true)
                {
                    //Generic Certificate hostname to use
                    //when SNI is disabled by client
                    GenericCertificateName = "google.com"
                };
    
                proxyServer.AddEndPoint(transparentEndPoint);
    
                //proxyServer.UpStreamHttpProxy = new ExternalProxy() { HostName = "localhost", Port = 8888 };
                //proxyServer.UpStreamHttpsProxy = new ExternalProxy() { HostName = "localhost", Port = 8888 };
    
                foreach (var endPoint in proxyServer.ProxyEndPoints)
                    Console.WriteLine("Listening on '{0}' endpoint at Ip {1} and port: {2} ",
                        endPoint.GetType().Name, endPoint.IpAddress, endPoint.Port);
    
                //Only explicit proxies can be set as system proxy!
                //proxyServer.SetAsSystemHttpProxy(explicitEndPoint);
                //proxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
    
                //wait here (You can use something else as a wait function, I am using this as a demo)
                Console.Read();
    
                //Unsubscribe & Quit
                proxyServer.BeforeRequest -= OnRequest;
                proxyServer.BeforeResponse -= OnResponse;
                proxyServer.ServerCertificateValidationCallback -= OnCertificateValidation;
                proxyServer.ClientCertificateSelectionCallback -= OnCertificateSelection;
    
                proxyServer.Stop();
            }
    
            public async Task OnRequest(object sender, SessionEventArgs e)
            {
                e.WebSession.Request.RequestHeaders.AddHeader("Ab", "Moo");
    
                var headers = e.WebSession.Request.RequestHeaders.GetAllHeaders();
    
                var ordered = headers.OrderBy(x => x.Name);
    
                e.WebSession.Request.RequestHeaders.Clear();
                
                foreach (var httpHeader in ordered)
                {
                    e.WebSession.Request.RequestHeaders.AddHeader(httpHeader);
                }
    
            }
    
            public async Task OnResponse(object sender, SessionEventArgs e)
            {
            }
    
            public Task OnCertificateValidation(object sender, CertificateValidationEventArgs e)
            {
                return null;
            }
    
            public Task OnCertificateSelection(object sender, CertificateSelectionEventArgs e)
            {
                return null;
            }
        }
    }
