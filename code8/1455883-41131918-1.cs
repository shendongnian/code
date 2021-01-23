    public class ExtractHeadersBehaviourExtension : BehaviorExtensionElement, IServiceBehavior
    {
        #region BehaviorExtensionElement Implementation
        public override Type BehaviorType
        {
            get
            {
                return typeof(ExtractHeadersBehaviourExtension);
            }
        }
        protected override object CreateBehavior()
        {
            return this;
        }
        #endregion
        #region IServiceBehavior Implementation
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            for (int i = 0; i < serviceHostBase.ChannelDispatchers.Count; i++)
            {
                ChannelDispatcher channelDispatcher = serviceHostBase.ChannelDispatchers[i] as ChannelDispatcher;
                if (channelDispatcher != null)
                {
                    foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        MessageInspector inspector = new MessageInspector();
                        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
                    }
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        #endregion
    }
    public class MessageInspector : IDispatchMessageInspector
    {
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            HeaderData headerData = request.Headers.GetHeader<HeaderData>("HeaderData", String.Empty);
            
            if(headerData != null)
            {
                OperationContext.Current.IncomingMessageProperties.Add("HeaderData", headerData);
            }
            return null;
        }
    }
