    using System.Fabric;
    using System.Security.Cryptography.X509Certificates;
    
    string clientCertThumb = "71DE04467C9ED0544D021098BCD44C71E183414E";
    string serverCertThumb = "A8136758F4AB8962AF2BF3F27921BE1DF67F4326";
    string CommonName = "www.clustername.westus.azure.com";
    string connection = "clustername.westus.cloudapp.azure.com:19000";
    
    var xc = GetCredentials(clientCertThumb, serverCertThumb, CommonName);
    var fc = new FabricClient(xc, connection);`
