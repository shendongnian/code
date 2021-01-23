    public class OperationResult
    {
        /// <summary>
        /// 1 : Success
        /// 2 : Fail 
        /// Maybe you can use Enum to set ResultCode.
        /// </summary>        
        public string ResultCode { get; set; }
         
        /// <summary>
        /// Exception message
        /// </summary>         
        public string ResultMessage { get; set; }
    }
