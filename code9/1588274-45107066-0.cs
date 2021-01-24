    // Example service call using a CustomBinding that is configured for client
    // authentication based on a user name and password sent as part of the message.
    var binding = new CustomBinding();
    
    TransportSecurityBindingElement securityBindingElement = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
    
    var secureTransport = new HttpsTransportBindingElement();
    secureTransport.UseDefaultWebProxy = false;
    secureTransport.ProxyAddress = new Uri("http://some-proxy");
    secureTransport.ProxyAuthenticationScheme = AuthenticationSchemes.Ntlm;
    
    binding.Elements.Add(securityBindingElement);
    binding.Elements.Add(secureTransport);
    
    var endpointAddress = new EndpointAddress("https://some-service");
    
    var factory = new ChannelFactory<IService>(binding, endpointAddress);
    // Credentials for authentication against the remote service
    factory.Credentials.UserName.UserName = "serviceUser";
    factory.Credentials.UserName.Password = "abc";
    // Credentials for authentication against the proxy server
    factory.Credentials.Windows.ClientCredential.UserName = "domain\user";
    factory.Credentials.Windows.ClientCredential.Password = "xyz";
    
    var client = factory.CreateChannel();
    client.CallMethod();
