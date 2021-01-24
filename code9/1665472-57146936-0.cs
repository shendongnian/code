lang-cs
using UnityEngine;
using System.ServiceModel;
using YourClientProxyNamespace;
public class WebClient : MonoBehavior
{
  void Start()
  {
    ProxyClient client = new ProxyClient(
        new BasicHttpBinding(BasicHttpSecurityMode.Transport),
        new EndpointAddress("https://YourWebServiceDomain/Service.svc"));
    var response = client.DesiredMethod();
    // Do whatever with the response
  }
}
