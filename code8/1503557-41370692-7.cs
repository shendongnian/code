    internal abstract class DynamicTransaction : BaseTransaction<DynamicTransactionObject>
    {
        protected new dynamic OpcClient
        {
            get { return base.OpcClient as dynamic; }
        }
        public DynamicTransaction()
        {
            var opcClient = new DynamicTransactionObject();
            // Access database, use IDictionary<string,object> interface to add properties to DynamicObject.
            base.OpcClient = opcClient;
        }
    }
