    public class AuthorizationResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public AuthorizationResult()
        {
            Result = true;
        }
        public AuthorizationResult(string errorMessage)
        {
            Result = false;
            Message = errorMessage;
        }
    }
