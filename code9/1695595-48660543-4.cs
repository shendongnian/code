    basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
    basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
    factory = new ChannelFactory<IAService_PortType>(basicHttpBinding, new EndpointAddress(new Uri("https://someurl.com/ws/TheEndpoint.pub.ws:AService")));
    factory.Credentials.UserName.UserName = "usern";
    factory.Credentials.UserName.Password = "passw";
    serviceProxy = factory.CreateChannel();
    ((ICommunicationObject)serviceProxy).Open();
    var opContext = new OperationContext((IClientChannel)serviceProxy);
    var prevOpContext = OperationContext.Current; // Optional if there's no way this might already be set
    OperationContext.Current = opContext;
    try
    {
        var result = await serviceProxy.getSomethingAsync("id").ConfigureAwait(false);
        // cleanup
        factory.Close();
        ((ICommunicationObject)serviceProxy).Close();
    }
    finally
    {
      // *** ENSURE CLEANUP *** \\
      CloseCommunicationObjects((ICommunicationObject)serviceProxy, factory);
      OperationContext.Current = prevOpContext; // Or set to null if you didn't capture the previous context
    }
