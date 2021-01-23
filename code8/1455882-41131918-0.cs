    public class FillHeaderDataBehaviourExtension : BehaviorExtensionElement, IEndpointBehavior
    {
        #region BehaviorExtensionElement Implementation
        public override Type BehaviorType
        {
            get
            {
                return typeof(FillHeaderDataBehaviourExtension);
            }
        }
        protected override object CreateBehavior()
        {
            return this;
        }
        #endregion
        #region IServiceBehaviour Implementation
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new MessageInspector());
        }
        #endregion
    }
    public class MessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            MessageHeader header = MessageHeader.CreateHeader("HeaderData", String.Empty, HeaderDataVM.GetInstance().GetBaseInstance());
            request.Headers.Add(header); // There is no need for checking if exist before adding. Every request has it's own headers.
            return null;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
