    using Microsoft.Azure.Management.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent;
    
    namespace CreateServiceBus
    {
        class Program
        {
            static void Main(string[] args)
            {
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(@"C:\Tom\azureCredential.txt");
                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();
                var sbNameSpace = "service bus name space";
                var resoureGroup = "resourcegroup";
                var serviceBusNamespace = azure.ServiceBusNamespaces
                    .Define(sbNameSpace)
                    .WithRegion(Region.USEast)
                    .WithNewResourceGroup(resoureGroup)
                    .WithSku(NamespaceSku.Basic)
                    .Create();
    
            }
        }
    }
