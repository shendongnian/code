    public class MaxItemsInGraphBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            foreach (OperationDescription operation in endpoint.Contract.Operations)
            {
                var dc = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (dc != null)
                {
                    dc.MaxItemsInObjectGraph = int.MaxValue;
                }
            }
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
