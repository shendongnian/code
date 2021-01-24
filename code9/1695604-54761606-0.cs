 lang-cs
BasicHttpBinding basicHttpBinding = 
    new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
// Setting it to Transport will give an exception if the url is not https
basicHttpBinding.Security.Transport.ClientCredentialType = 
    HttpClientCredentialType.Ntlm;
ChannelFactory<IAService_PortType> factory = 
    new ChannelFactory<IAService_PortType>(basicHttpBinding, 
    new EndpointAddress(
        new Uri("https://someurl.com/ws/TheEndpoint.pub.ws:AService")));
factory.Credentials.Windows.ClientCredential.Domain = domain;
factory.Credentials.Windows.ClientCredential.UserName = user;
factory.Credentials.Windows.ClientCredential.Password = pass;
IAService_PortType serviceProxy = factory.CreateChannel();
((ICommunicationObject)serviceProxy).Open();
try
{
    var result = serviceProxy.getSomethingAsync("id").Result;
}
finally
{
    // cleanup
    factory.Close();
    ((ICommunicationObject)serviceProxy).Close();
}
