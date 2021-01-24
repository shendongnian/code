    public class ExternalSystemCallException : Exception
    {
        public string FailedSystem { get; }
        public string OperationName { get; }
        public ExternalSystemCallException(
                 string failedSystem, 
                 string operationName, 
                 Exception innerException = null)
                : base($"Operation {operationName} failed in {failedSystem}", innerException) {
            FailedSystem = failedSystem;
            OperationName = operationName;
        }        
    }
