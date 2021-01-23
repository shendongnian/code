    public class LogOperationInspector : IParameterInspector
    {
        public object BeforeCall(string operationName, object[] inputs)
        {
            // Before Call
        }
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            // Sucessful response 
        }
    }
    public class LogErrorInspector : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            // Error Handling
        }
        public bool HandleError(Exception error)
        {
            // Error Handling
        }
    }
