    internal class LoggingOperationBehavior : IOperationBehavior
    {
        public void Validate(OperationDescription operationDescription)
        {
            
        }
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new LoggingOperationInvoker(dispatchOperation.Invoker, dispatchOperation);
        }
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            
        }
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }
    }
