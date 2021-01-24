    BasicHttpBinding basicHttpBinding = null;
    EndpointAddress endpointAddress = null;
    ChannelFactory<IAService> factory = null;
    IAService serviceProxy = null;
    try
    {
        basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
        basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
        endpointAddress = new EndpointAddress(new Uri("https://someurl.com/ws/TheEndpoint.pub.ws:AService"));
        factory = new ChannelFactory<IAService>(basicHttpBinding, endpointAddress);
        factory.Credentials.UserName.UserName = "usrn";
        factory.Credentials.UserName.Password = "passw";
        serviceProxy = factory.CreateChannel();
        using (var scope = new OperationContextScope((IContextChannel)serviceProxy))
        {
            var result = await serviceProxy.getSomethingAsync("id").ConfigureAwait(false);
        }
        factory.Close();
        ((ICommunicationObject)serviceProxy).Close();
    }
    catch (MessageSecurityException ex)
    {
         throw;
    }
    catch (Exception ex)
    {
        throw;
    }
    finally
    {
        // *** ENSURE CLEANUP (this code is at the WCF GitHub page *** \\
        CloseCommunicationObjects((ICommunicationObject)serviceProxy, factory);
    }
