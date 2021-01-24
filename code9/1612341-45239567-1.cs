    public class SimpleEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(
                new SimpleMessageInspector()
                );
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        { 
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
 
    public class SimpleMessageInspector : IClientMessageInspector, IDispatchMessageInspector    
    {
            public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)    
            {
            }     
    
            public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)    
            {    
     
                //modify the request send from client(only customize message body)
    
                request = TransformMessage2(request);
    
                //you can modify the entire message via following function
    
                //request = TransformMessage(request);    
    
                return null;    
            }   
     
    }
     
