    public class CleanOperationBehavior: Attribute, IOperationBehavior
    {
        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            //Putting ourself in between dispatching invoker
            dispatchOperation.Invoker = new CleanOperationInvoker(dispatchOperation.Invoker);
        }
    }
