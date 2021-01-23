    public class ServiceClientBase<T> : ClientBase<T>, IServiceClient, ICommunicationObject where T : class
    {
        #region Constructor
        public ServiceClientBase(Binding binding, EndpointAddress endpointAddress, sc.IKnownTypeGetter knownTypeGetter) : base(binding, endpointAddress)
        {
            foreach (var operation in Endpoint.Contract.Operations)
            {
                var knownTypes = knownTypeGetter.GetKnownTypes();
    
                foreach (var type in knownTypes)
                {
                    operation.KnownTypes.Add(type);
                }
            }
        }
        #endregion
    
        #region Open/Close
        public virtual Task OpenAsync()
        {
            var communicationObject = this as ICommunicationObject;
            return Task.Factory.FromAsync(communicationObject.BeginOpen(null, null), new Action<IAsyncResult>(communicationObject.EndOpen));
        }
    
        public virtual Task CloseAsync()
        {
            var communicationObject = this as ICommunicationObject;
            return Task.Factory.FromAsync(communicationObject.BeginClose(null, null), new Action<IAsyncResult>(communicationObject.EndClose));
        }
        #endregion
    }
