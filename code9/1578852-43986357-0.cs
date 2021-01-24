    ServiceReference1.ServiceClient stub = new ServiceReference1.ServiceClient();
    stub.ClientCredentials.UserName.UserName = username;  
    stub.ClientCredentials.UserName.Password = password;  
    // Treat the test certificate as trusted  
    stub.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.PeerOrChainTrust;  
