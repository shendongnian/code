    public class ArgumentExceptionEx : ArgumentException
    {
        public int ErrorCode { get; }
        public ArgumentExceptionEx(string paramName, int errorCode)
            : base (paramName)    
        {
            ErrorCode = errorCode;
        }
    }
