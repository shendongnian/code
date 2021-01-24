	ServiceName_PortClient client = new ServiceName_PortClient();
	//GetBindingForEndpoint returns a BasicHttpBinding
	var httpBinding = client.Endpoint.Binding as BasicHttpBinding;
	httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Digest;
	client.ClientCredentials.HttpDigest.ClientCredential = new NetworkCredential("Username", "Password", "Digest");
	var result = await client.GetResultAsync();
Now, if you don't need to do any authentication simply doing:
	ServiceName_PortClient client = new ServiceName_PortClient();
	var result = await client.GetResultAsync();
Should be sufficient.
The `ServiceName_PortClient` class was generated as such by the import tool, where `ServiceName` was the name of the service I was importing.
Of course it seems to be more in the spirit of the imported code to place the configuration in a partial `ServiceName_PortClient` class along the lines of:
    public partial class ServiceName_PortClient
    {
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials)
        {
			var httpBinding = serviceEndpoint.Binding as BasicHttpBinding;
            httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Digest;
            clientCredentials.HttpDigest.ClientCredential = new NetworkCredential("Username", "Password", "Realm");
        }
    }
  [1]: https://docs.microsoft.com/en-us/dotnet/core/additional-tools/wcf-web-service-reference-guide
