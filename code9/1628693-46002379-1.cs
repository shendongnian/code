         internal class MyFaultFormatterBehavior : IEndpointBehavior
    {
       ...
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new MyClientMessageInspector(endpoint));
        }
    }
