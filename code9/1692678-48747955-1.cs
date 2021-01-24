    public class CustomEndpointBehavior : IEndpointBehavior
    {
       public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
       {
          clientRuntime.ClientMessageInspectors.Add(new ClientMessageInspector());
       }
       ...
    }
