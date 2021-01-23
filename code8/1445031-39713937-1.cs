    public partial class WCFClientBase<T> : ClientBase<T> where T : class
    {
        public WCFClientBase(Binding binding, EndpointAddress endpointAddress, IKnownTypeGetter knownTypeGetter) : base(binding, endpointAddress)
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
    }
