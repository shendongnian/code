    public class BusinessLogicMessage<T> where T : new()
        {
            public BusinessLogicMessage(T result)
            {
                Result = result;
                Status = BusinessLogicStatus.Success;
                Message = string.Empty;
            }
    
            public BusinessLogicMessage(T result, BusinessLogicStatus status, string message)
            {
                Result = result;
                Status = status;
                Message = message;
            }
    
            public BusinessLogicStatus Status { get; set; }
            public string Message { get; set; }
            public T Result { get; set; }
        }
    
        public class BusinessLogicMessage
        {
            public BusinessLogicMessage()
            {
                Status = BusinessLogicStatus.Success;
                Message = string.Empty;
            }
    
            public BusinessLogicMessage(BusinessLogicStatus status, string message)
            {
                Status = status;
                Message = message;
            }
    
            public BusinessLogicStatus Status { get; set; }
            public string Message { get; set; }
        }
    
        public enum BusinessLogicStatus
        {
            Success,
            Failure,
            Warning
        }
