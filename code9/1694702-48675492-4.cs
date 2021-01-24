    using System.Net.Sockets;
    using System.Net.Security;
    using System.Security.Authentication;
    using System.Security.Authentication.ExtendedProtection;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | 
                                           SecurityProtocolType.Tls | 
                                           SecurityProtocolType.Tls11 | 
                                           SecurityProtocolType.Tls12;
    ServicePointManager.ServerCertificateValidationCallback += TlsValidationCallback;
