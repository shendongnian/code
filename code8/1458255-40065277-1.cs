    public class LogOperationInspector : IParameterInspector
    {
        public object BeforeCall(string operationName, object[] inputs)
        {
            CallContext.SetData("CallContext", CallObj);
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
            var CallObj = CallContext.GetData("CallContext");
        }
        public bool HandleError(Exception error)
        {
            // Error Handling
        }
    }
       
